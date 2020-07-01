using EMBusinessLayer.IinterfaceBL;
using EMBusinessLayer.serviceBL;
using EMSampleRepositoryLayer.interfaceRepository;
using EMSampleRepositoryLayer.serviceRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////Dependency Injection for Business layer
            services.AddTransient<IEmployeeBL,EmployeeBL>();

            ////Dependency Injection for Repository layer
            services.AddTransient<IEmployeeRL, EmployeeRL>();

            ////Dependency Injection for Business layer
            services.AddTransient<IUserBl,UserBL> ();

            ////Dependency Injection for Repository layer
            services.AddTransient<IUserRL, UserRL>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
