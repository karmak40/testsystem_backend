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
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Repositories;
using testsystem.Services;

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

          

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
