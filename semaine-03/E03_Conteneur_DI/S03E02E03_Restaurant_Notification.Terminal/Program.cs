using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant;

internal static class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddScoped<INotificationCommande, NotificationConsole>();
        builder.Services.AddScoped<ServiceCommandes>();

        using IHost host = builder.Build();
        using (IServiceScope scope = host.Services.CreateScope())
        {
            ServiceCommandes service = scope.ServiceProvider
                .GetRequiredService<ServiceCommandes>();
            service.Creer(1001);
        }
    }
}
