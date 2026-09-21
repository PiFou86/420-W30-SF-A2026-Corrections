namespace Restaurant;

public sealed class ServiceCommandes
{
    private readonly INotificationCommande m_notification;

    public ServiceCommandes(INotificationCommande notification)
    {
        ArgumentNullException.ThrowIfNull(notification);
        m_notification = notification;
    }

    public Commande Creer(int numeroCommande)
    {
        Commande commande = new(numeroCommande);
        m_notification.NotifierCreation(commande.Numero);
        return commande;
    }
}
