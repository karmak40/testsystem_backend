using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using testsystem.context;
using testsystem.Interfaces.Email;
using testsystem.Interfaces.Internal.Mail;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Internal;
using testsystem.Repositories;
using testsystem.Services;
using testsystem.Services.Email;
using testsystem.Services.Internal;
using Hangfire;
using Hangfire.MySql;
using System.Transactions;
using Hangfire.MySql.Core;

namespace testsystem
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<MyContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPositionService, PostionService>();
            services.AddTransient<IPositionRepository, PositionRepository>();

            services.AddTransient<ICandidatService, CandidatService>();
            services.AddTransient<ICandidatRepositories, CandidatRepositories>();

            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestService, TestService>();

            services.AddTransient<IViewerRepository, ViewerRepository>();
            services.AddTransient<IViewerService, ViewerService>();

            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IAnswerService, AnswerService>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, AuthMessageSender>();

            services.AddTransient<IEmailSendService, EmailSendService>();

          /*  services.AddHangfire(a =>
            {
                GlobalConfiguration.Configuration.UseStorage(
                new MySqlStorage(
                    Configuration.GetConnectionString("HangFire"),
                    new MySqlStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(60),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true,
                        DashboardJobListLimit = 50000,
                        TransactionTimeout = TimeSpan.FromMinutes(1),
                    }));
            });*/

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStopping.Register(OnShutdown);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


/*
            app.UseHangfireServer(
                 new BackgroundJobServerOptions
                 {
                     WorkerCount = 1
                 });
         
            app.UseHangfireDashboard();

    */

            app.UseMvc();
        }
        private void OnShutdown()
        {
            DisposeServers();
        }

        internal static bool DisposeServers()
        {
            try
            {
                var type = Type.GetType("Hangfire.AppBuilderExtensions, Hangfire.Core", throwOnError: false);
                if (type == null) return false;

                var field = type.GetField("Servers", BindingFlags.Static | BindingFlags.NonPublic);
                if (field == null) return false;

                var value = field.GetValue(null) as ConcurrentBag<BackgroundJobServer>;
                if (value == null) return false;

                var servers = value.ToArray();

                foreach (var server in servers)
                {
                    // Dispose method is a blocking one. It's better to send stop
                    // signals first, to let them stop at once, instead of one by one.
                    server.SendStop();
                }

                foreach (var server in servers)
                {
                    server.Dispose();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
