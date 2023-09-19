using Microsoft.OpenApi.Models;

namespace BoilerPlate.CustomHandlers
{
    public static class CustomSwaggerHandler
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "BoilerPlate.xml"));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BoilerPlateAPI",
                    Version = "v1",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter the JWT Token with Bearer format like (Bearer[space] Token)"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id= "Bearer",
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }
    }
}
