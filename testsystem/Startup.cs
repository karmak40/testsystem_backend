using System;
using System.Collections.Generic;
using System.Linq;
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


            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, AuthMessageSender>();

            services.AddTransient<IEmailSendService, EmailSendService>();

            services.AddHangfire(a =>
            {
                GlobalConfiguration.Configuration.UseStorage(
                new MySqlStorage(
                    Configuration.GetConnectionString("HangFire"),
                    new MySqlStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(15),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true,
                        DashboardJobListLimit = 50000,
                        TransactionTimeout = TimeSpan.FromMinutes(1),
                    }));
            });

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireServer(
                 new BackgroundJobServerOptions
                 {
                     WorkerCount = 1
                 });

            app.UseHangfireDashboard();



            app.UseMvc();
        }
    }
}
