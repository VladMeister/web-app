using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductTracking.BL.MappingProfiles;
using ProductTracking.BL.Services;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Repositories;
using ProductTracking.DAL.Repositories.Interfaces;
using ProductTracking.DAL.UnitOfWork;
using ProductTracking.MVC.MappingProfiles;

namespace ProductTracking.MVC
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
            services.AddRazorPages();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IRealizationPlaceRepository, RealizationPlaceRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRealizationPlaceService, RealizationPlaceService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ProductTrackingContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("ProductTracking")));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MvcMappingProfile());
                mc.AddProfile(new BLMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Index");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
