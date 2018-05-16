using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicSite.Controllers;
using MusicSite.Models.Repositories;

namespace MusicSite
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
            services.AddDbContext<MusicDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("MusicSiteConnection"))); //MusicSiteConnection
            services.AddMvc();
            services.AddScoped<MusicDBContext>();
            services.AddTransient<IRepository<Song>, MusicRepository<Song>>();
            services.AddTransient<IRepository<Singer>, MusicRepository<Singer>>();
            services.AddTransient<IRepository<Album>, MusicRepository<Album>>();
            services.AddTransient<IMusicDbContextRepository, MusicDbContextRepository>();
            services.AddTransient<MusicDbContextRepository>();
            services.AddTransient<StorageProcedure>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
