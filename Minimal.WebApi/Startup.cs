namespace Minimal.WebApi;

using Minimal.WebApi.Extensions;
using System.Reflection;

internal class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) =>
        _configuration = configuration;

    public void ConfigureServices(IServiceCollection services) =>
        services
            .AddSwagger()
            .AddJwtAuthentication(_configuration)
            .AddDbContext(_configuration)
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddControllers();

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment) =>
        application
            .OnDevelopment(() => application.UseSwagger().UseSwaggerUI(), environment)
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers());
}