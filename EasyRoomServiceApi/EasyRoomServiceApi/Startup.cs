using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EasyRoomServiceApi
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
            //Add Service core with default policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000",
                                            "https://easyroom.azurewebsites.net").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //Register EF DB Context
            services.AddDbContext<EasyRoomContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //EF Database Exception filter (provide helpfull error information in the development environment
            services.AddDatabaseDeveloperPageExceptionFilter();

            //Authorizatio from JWT
            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);

            //To validate the token which has been sent by clients
            var appSetting = jwtSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSetting.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            //Register the Swagger generator,
            services.AddSwaggerGen();

            //Add services
            services.AddTransient<FriendService>();
            services.AddTransient<InterestService>();
            services.AddTransient<MessageService>();
            services.AddTransient<NotificationService>();
            services.AddTransient<PostService>();
            services.AddTransient<RegisterService>();
            services.AddTransient<UserService>();
            services.AddTransient<SearchService>();

            services.AddControllersWithViews();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //add cors
            app.UseCors();

            //Autorization and authentication using JWT(json web token)
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
