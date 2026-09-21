using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Application;
using Restaurant.Infrastructure;

internal static class Program
{
    public static void Main(string[] args)
    {
        if (args.Contains("--manuel"))
        {
            ExecuterManuellement();
        }
        else
        {
            ExecuterAvecConteneur(args);
        }
    }

    private static void ExecuterManuellement()
    {
        IDepotCommandes depot = new DepotCommandesMemoire();
        INotificationCommande notification = new NotificationConsole();
        CreerCommande creerCommande = new(depot, notification);
        creerCommande.Executer(1001);
    }

    private static void ExecuterAvecConteneur(string[] arguments)
    {
        HostApplicationBuilder builder =
            Host.CreateApplicationBuilder(arguments);
        builder.Services.AddScoped<IDepotCommandes, DepotCommandesMemoire>();
        builder.Services.AddScoped<INotificationCommande, NotificationConsole>();
        builder.Services.AddScoped<CreerCommande>();

        using IHost host = builder.Build();
        using (IServiceScope scope = host.Services.CreateScope())
        {
            CreerCommande creerCommande = scope.ServiceProvider
                .GetRequiredService<CreerCommande>();
            creerCommande.Executer(1001);
        }
    }
}
