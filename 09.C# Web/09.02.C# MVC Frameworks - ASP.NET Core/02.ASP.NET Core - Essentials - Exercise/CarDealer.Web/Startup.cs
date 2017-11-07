using CarDealer.Web.Data;
using CarDealer.Web.Models;
using CarDealer.Web.Services.Contracts;
using CarDealer.Web.Services.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


namespace CarDealer.Web
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
            services.AddDbContext<CarDealerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            // here goes the services 
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddMvc();
            services.AddDbContext<CarDealerDbContext>(options =>
                options.UseSqlServer(AppSettings.DatabaseConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}