using Microsoft.OpenApi.Models;

namespace api_user_security.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api User Security",
                    Description = "Modulo Seguridad",
                    Contact = new OpenApiContact { Name = "Experis", Email = "jhon.Chonta@viaexperis2.com", Url = new Uri("https://www.experis.pe") }
                });

                //swg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //	Description = "Input the JWT like: Bearer {your token}",
                //	Name = "Authorization",
                //	Scheme = "Bearer",
                //	BearerFormat = "JWT",
                //	In = ParameterLocation.Header,
                //	Type = SecuritySchemeType.ApiKey
                //});

                //swg.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //	{
                //		new OpenApiSecurityScheme
                //		{
                //			Reference = new OpenApiReference
                //			{
                //				Type = ReferenceType.SecurityScheme,
                //				Id = "Bearer"
                //			}
                //		},
                //		Array.Empty<string>()
                //	}
                //});

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            /*app.UseSwagger(options =>
	        {
		        options.SerializeAsV2 = true;
	        });*/

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseSwaggerUI();
        }
    }
}
