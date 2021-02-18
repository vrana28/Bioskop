using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioskop.Domen;
using Bioskop.Podaci.UnitOfWork;
using Bioskop.Podaci.UnitOfWork.Korisnici;
using Bioskop.WebApp.Filters;
using Bioskop.WebApp.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bioskop.WebApp
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
            // servisi za sesije
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);    // nakon nekog vremena brise se sesija
            });

            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, BioskopUnitOfWork>(); // ovde smo registrovali servis koji ce da se poziva kod kontrolera,
            // odnosno kad controler zatrazi IunitOfWork ti mu prosledi BioskopUnitOfWork..
            services.AddScoped<IKorisniciUnitOfWork, KorisniciUnitOfWork>();
            services.AddScoped<LoggedInKorisnik>();
            services.AddScoped<NotLoggedIn>();
            services.AddDbContext<BioskopContext>(); // moramo i kontekst da ubacimo
            services.AddDbContext<KorisnikContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseSession(); // sesija treba da se koristi nakon rutiranja i pre endpoint-a
           // app.UseCheckIfUserIsLoggedInMiddleware(); // mora da  se void racuna o redosledu
            app.UseAuthorization();

            //localhost:9999/Bioskop/Index/5
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Korisnik}/{action=Login}/{id?}");
            });
        }
    }
}
