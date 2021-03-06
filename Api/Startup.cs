using AutoMapper;
using BoilerplateDotnetCorePostgres.Configurations.Jwt;
using BoilerplateDotnetCorePostgres.Middlewares;
using Business;
using Business.Blog;
using Business.Post;
using Common;
using Dal;
using Dal.Blog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Security;
using Service.Caching;

namespace BoilerplateDotnetCorePostgres
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
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
             options.SuppressModelStateInvalidFilter = true; //prevent automatic 400 response
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            });

            //Injecting the db context and uow
            services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("BlogContext")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Injecting the identity manager
            services.AddIdentity< Dal.Entities.Identity.ApplicationUser,
                Dal.Entities.Identity.ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BlogDbContext>();

            // Add functionality to inject IOptions<T>
            services.AddOptions();
            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("Keys"));

            services.AddTransient<IBlogBusiness, BlogBusiness>();
            services.AddTransient<IPostBusiness, PostBusiness>();
            services.AddTransient<ISecurity, JwtSecurity>();

            services.AddTransient<ICacheService, CacheService>();

            services.AddAutoMapper(typeof(MappingProfile));

            //todo: configure cors properly
            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                //policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });

            services.ConfigureJwtAuthentication();
            services.ConfigureJwtAuthorization();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();

            //request handling
            app.UseRequestMiddleware();

            app.UseRouting();
            app.UseCors("policy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
