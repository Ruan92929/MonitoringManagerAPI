using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MonitoringManagerAPI.Data;
using MonitoringManagerAPI.Helpers.Swagger;
using MonitoringManagerAPI.Infra.Users;
using MonitoringManagerAPI.Service.Authenticate;
using MonitoringManagerAPI.Service.Users;
using System.Text;

namespace MonitoringManagerAPI.Extensions.Register
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped<DbSession>();
            services.AddSingleton<DapperContext>();

            //DI Repository
            services.AddScoped<IUserRepository, UserRepository>();

            //DI Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.AddSwaggerConfiguration();

            var key = Encoding.UTF8.GetBytes("K0zLl1IM8Z8nECy5Zt3J+0/vXG4Q8qD5aZ2bL6XwVxA=");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            return services;
        }
    }
}
