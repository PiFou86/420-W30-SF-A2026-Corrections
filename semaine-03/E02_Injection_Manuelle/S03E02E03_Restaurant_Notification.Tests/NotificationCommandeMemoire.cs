using Restaurant;

namespace Restaurant.Tests;

public sealed class NotificationCommandeMemoire : INotificationCommande
{
    public int? DernierNumeroCommande { get; private set; }

    public void NotifierCreation(int numeroCommande)
    {
        DernierNumeroCommande = numeroCommande;
    }
}
