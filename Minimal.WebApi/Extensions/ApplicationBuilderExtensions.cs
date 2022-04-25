namespace Minimal.WebApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder OnDevelopment(
        this IApplicationBuilder application,
        Action action,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            action();
        }

        return application;
    }
}
