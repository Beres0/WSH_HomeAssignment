using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WSH_HomeAssignment.Api.Background;
using WSH_HomeAssignment.Api.Services.Authentication;
using WSH_HomeAssignment.Api.Services.ExchangeRates;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Authentication;
using WSH_HomeAssignment.Infrastructure.Data;
using WSH_HomeAssignment.Infrastructure.Data.Repositories;
using WSH_HomeAssignment.Infrastructure.ExchangeRatesService;
using WSH_HomeAssignment.Infrastructure.ExchangeRatesServices;

namespace WSH_HomeAssignment.Api
{
    public static class ServiceConfiguration
    {
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExchangeRateDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IDailyExchangeRateRepository, DailyExchangeRateRepository>();
            services.AddTransient<ISavedExchangeRateRepository, SavedExchangeRateRepository>();
        }
        private static void AddLogging(WebApplicationBuilder builder)
        {
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
        }

        private static void AddAuthentication(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = DomainConstants.PasswordRequiredLength;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ExchangeRateDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration[$"JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
                };
            });
            services.AddTransient<ITokenService, JwtTokenService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        private static void AddExchangeRateServices(IServiceCollection services)
        {
            services.AddTransient<DailyExchangeRatesXmlParser>();
            services.AddTransient<MNBArfolyamServiceSoapClient>();
            services.AddTransient<IExternalExchangeRatesService, MNBExchangeRatesService>();
            services.AddTransient<ICachedExchangeRatesService, CachedExchangeRatesService>();
            services.AddTransient<IExchangeRatesService, CachedExchangeRatesService>();
            services.AddHostedService<CurrentExchangeRatesRequester>();
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.MapType<DateDto>(() =>
                {
                    return new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "date"
                    };
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                var key = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { key, Array.Empty<string>() }
            });
            });
        }

        private static void AddAppServices(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationAppService, AuthenticationAppService>();
            services.AddTransient<IExchangeRatesAppService, ExchangeRatesAppService>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            AddLogging(builder);
            AddDbContext(services, builder.Configuration);
            AddAuthentication(services, builder.Configuration);
            AddRepositories(services);
            AddExchangeRateServices(services);
            AddAppServices(services);
            AddSwagger(services);
            return services;
        }
    }
}