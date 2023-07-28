using api_user_security.Configurations;
using Negocio.Authorization;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

#region add services to DI container
{
    var services = builder.Services;
    var config = builder.Configuration;

    #region Configurations
    services.AddCors();
    services.AddControllers();
    services.AddEndpointsApiExplorer();

    // Culture Config
    services.AddCultureConfiguration(config);

    // IoC Setting
    services.AddDependencyInjectionConfiguration(config);

    // Swagger Configurations
    services.AddSwaggerConfiguration();

    #endregion

}
#endregion


var app = builder.Build();

#region Configure the HTTP request pipeline.
//if (env.IsDevelopment())
//{
//}

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());    

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();
    //app.MapControllers();
}

app.Run();

#endregion