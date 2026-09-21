using Restaurant.Domaine;

namespace Restaurant.Application;

public sealed class CreerCommande
{
    private readonly IDepotCommandes m_depot;
    private readonly INotificationCommande m_notification;

    public CreerCommande(
        IDepotCommandes depot,
        INotificationCommande notification)
    {
        ArgumentNullException.ThrowIfNull(depot);
        ArgumentNullException.ThrowIfNull(notification);
        m_depot = depot;
        m_notification = notification;
    }

    public void Executer(int numeroCommande)
    {
        Commande commande = new(numeroCommande);
        m_depot.Ajouter(commande);
        m_notification.NotifierCreation(commande.Numero);
    }
}
