using BlazorServerApp.Data;
using BlazorServerApp.Entities;
using BlazorServerApp.Seeder;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerApp.Seeder;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BlazorServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            //services.AddScoped<MemberService>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddDbContext<MembersDbContext>();


            services.AddSingleton<IContactService, ContactService>();
            //services.AddSingleton<ContactService>();
            //services.AddScoped<ContactService>();

            services.AddScoped<MemberListSeeder>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MemberListSeeder seedMembers)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //seed random members to the database
            seedMembers.Seed(10);

            // Seed the database with some contacts
            ContactListSeeder seederContactList = new ContactListSeeder(app.ApplicationServices.GetService<IContactService>());
            seederContactList.Seed();


            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        //static void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddRazorPages();
        //    services.AddServerSideBlazor();
        //    services.AddSingleton<WeatherForecastService>();
        //    services.AddSingleton<ContactService>();
        //}
    }
}
