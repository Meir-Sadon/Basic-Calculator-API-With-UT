using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Calculator_MatrixJobExam.Extensions
{
    /// <summary>
    /// Provides extension methods for adding services to the dependency injection container.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Add JWT Authorization/Authentication service to the application
        /// </summary>
        /// <param name="services">The service collection to add the authentication services to.</param>
        /// <param name="configuration">The configuration manager to retrieve JWT settings from.</param>
        internal static void AddJWTAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            string? secretKey = configuration["Jwt:SecretKey"];
            ArgumentException.ThrowIfNullOrEmpty(secretKey, nameof(secretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }
    }
}
