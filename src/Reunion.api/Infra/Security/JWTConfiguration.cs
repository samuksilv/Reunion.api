using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reunion.api.Infra.Security;

namespace Reunion.api.Infra.Security
{
    public static class JWTConfiguration
    {

        public static IServiceCollection AddJwt(this IServiceCollection services, WebApplicationBuilder builder)
        {
            TokenConfigurations tokenConfigurations = GetTokenConfigurationsFromConfig(builder);

            services.AddSingleton(tokenConfigurations);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfigurations.SecretJwtKey));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            // services.AddAuthorization(auth =>
            // {
            //     auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //         .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //         .RequireAuthenticatedUser()
            //         .Build());
            // });

            return services;
        }


        private static TokenConfigurations GetTokenConfigurationsFromConfig(WebApplicationBuilder builder)
        {
            TokenConfigurations tokenConfigurations = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                builder.Configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            return tokenConfigurations;
        }
    }
}