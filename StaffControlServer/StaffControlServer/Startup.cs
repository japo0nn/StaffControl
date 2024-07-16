using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Helpers;
using StaffControlServer.Services;

namespace StaffControlServer
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
            string connection = Configuration.GetConnectionString("DevConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connection));

            services.AddScoped<TaskFilterService>();

            services.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(o =>
                   o.ValidationInterval = TimeSpan.FromMinutes(1));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = false,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        if (string.IsNullOrEmpty(accessToken) == false)
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials());
            });

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddControllers(
             options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StaffControl.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                  new OpenApiSecurityScheme
                  {
                      Description = "JWT Authorization header using the Bearer scheme.",
                      Type = SecuritySchemeType.Http,
                      Scheme = "bearer"
                  });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                        }
                        },new List<string>()
                    }
                });
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaffControl.WebApi v1"));
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = scope.ServiceProvider.GetService<AppDbContext>();
                db.Database.Migrate();
            }
            app.UseCors("CorsPolicy");

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
