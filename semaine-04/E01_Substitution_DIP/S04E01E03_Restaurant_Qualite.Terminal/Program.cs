using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Qualite;

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
        INotificationCommande notification = new NotificationConsole();
        ServiceCommandes service = new(notification);
        Commande commande = service.Creer(1001, 40m, new Client("client@exemple.ca"));
        Console.Out.WriteLine($"Total : {commande.SousTotal + commande.Taxe:C}");
    }

    private static void ExecuterAvecConteneur(string[] arguments)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(arguments);
        builder.Services.AddScoped<INotificationCommande, NotificationConsole>();
        builder.Services.AddScoped<ServiceCommandes>();

        using IHost hote = builder.Build();
        using (IServiceScope portee = hote.Services.CreateScope())
        {
            ServiceCommandes service = portee.ServiceProvider
                .GetRequiredService<ServiceCommandes>();
            Commande commande = service.Creer(1001, 40m, new Client("client@exemple.ca"));
            Console.Out.WriteLine($"Total : {commande.SousTotal + commande.Taxe:C}");
        }
    }
}
