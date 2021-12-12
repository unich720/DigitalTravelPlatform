using DigitalTravelPlatform.Auth;
using DTP.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using static DTP.Entity.ConnectingHelper;

namespace DigitalTravelPlatform
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(option =>
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(option =>
                option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            var sqlConnBinder = new SqlConnString();
            Configuration.GetSection("DigitalTravelPlatformDB").Bind(sqlConnBinder);

            services.AddScoped<DTPProcessor>();
            services.AddDbContext<DTPDBContext>(options =>
            {
                options.UseSqlServer(ConnectingHelper.BuildConnectionString(new SqlConnectionStringBuilder(), sqlConnBinder));
            });

            services.Configure<BasicAuthSettings>(Configuration.GetSection("BasicAuth"));
            services.AddAuthentication("BasicAuthentication").
                AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
