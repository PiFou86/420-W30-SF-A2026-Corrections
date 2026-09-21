namespace Restaurant.Qualite;

public class NotificationConsole : INotificationCommande
{
    public void NotifierCreation(int numeroCommande, string courriel)
    {
        Console.Out.WriteLine($"Commande {numeroCommande} créée pour {courriel}.");
    }
}
