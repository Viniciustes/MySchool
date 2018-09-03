using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;
using MySchool.Infrastructure.Repositories;
using MySchool.Service.Interfaces;
using MySchool.Service.Services;

namespace MySchool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MySchoolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MySchoolConnection")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IServiceCourse, ServiceCourse>();
            services.AddScoped<IRepositoryCourse, RepositoryCourse>();

            services.AddScoped<IServiceStudent, ServiceStudent>();
            services.AddScoped<IRepositoryStudent, RepositoryStudent>();

            services.AddScoped<IServiceInstructor, ServiceInstructor>();
            services.AddScoped<IRepositoryInstructor, RepositoryInstructor>();

            services.AddScoped<IServiceDepartment, ServiceDepartment>();
            services.AddScoped<IRepositoryDepartment, RepositoryDepartment>();

            services.AddScoped<IServiceCourseAssignment, ServiceCourseAssignment>();
            services.AddScoped<IRepositoryCourseAssignment, RepositoryCourseAssignment>();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}