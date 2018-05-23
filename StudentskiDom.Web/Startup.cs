﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using StudentskiDom.Data.EF;

namespace StudentskiDom.Web
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
            
            services.AddDbContext<MojContext>(options =>

               options.UseSqlServer(Configuration.GetConnectionString("APP")));
			services.AddMvc();

			services.AddDistributedMemoryCache();
			services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
				routes.MapRoute(
			       name: "areas",
			       template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				

				routes.MapRoute(
                    name: "default",
                    template: "{controller=Autentifikacija}/{action=Index}/{id?}");


            });
        }
    }
}
