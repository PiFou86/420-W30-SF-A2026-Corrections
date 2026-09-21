using Restaurant.Application;

namespace Restaurant.Infrastructure;

public sealed class NotificationConsole : INotificationCommande
{
    public void NotifierCreation(int numeroCommande)
    {
        Console.Out.WriteLine($"Commande {numeroCommande} créée.");
    }
}
