using FindJobSolution.Application.Catalog;
//using FindJobSolution.Application.Catalog.Cvs;
using FindJobSolution.Application.Catalog.JobInformations;
using FindJobSolution.Application.Catalog.Jobs;
using FindJobSolution.Application.Catalog.Skills;
using FindJobSolution.Application.Common;
using FindJobSolution.Application.System.UsersJobSeeker;
using FindJobSolution.Application.System.UsersRecuiter;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FindJobSolution.API
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
            services.AddDbContext<FindJobDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
            services.AddIdentity<User,Role>()
                .AddEntityFrameworkStores<FindJobDBContext>()
                .AddDefaultTokenProviders();    

            //Declare DI
            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IJobSeekerService, JobSeekerService>();
            services.AddTransient<IJobInformationService, JobInformationService>();
            //services.AddTransient<ICvService, CvService>();
            services.AddTransient<ISkillService, SkillService>();

            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            
            services.AddTransient<IUserRecuiterService, UserRecuiterService>();
            services.AddTransient<IUserJobSeekerService, UserJobSeekerService>();



            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger FindJob Solution", Version = "v1" });

            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger FindJob V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}
