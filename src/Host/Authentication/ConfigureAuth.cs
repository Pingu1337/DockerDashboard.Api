using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Host.Authentication;

public static class ConfigureAuth
{
    public static void AddApiKeyAuthentication(this SwaggerGenOptions c)
    {
        c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "ApiKey must appear in header",
            Type = SecuritySchemeType.ApiKey,
            Name = "X-API-KEY",
            In = ParameterLocation.Header,
            Scheme = "ApiKeyScheme"
        });

        var key = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey"
            },
            In = ParameterLocation.Header
        };

        var requirement = new OpenApiSecurityRequirement
        {
            { key, new List<string>() }
        };
        c.AddSecurityRequirement(requirement);
    }

    public static void AddApiKeyAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication("ApiKey")
            .AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationSchemeHandler>(
                "ApiKey",
                opts => opts.ApiKey = configuration.GetValue<string>("ApiKey")
            );
    }
}