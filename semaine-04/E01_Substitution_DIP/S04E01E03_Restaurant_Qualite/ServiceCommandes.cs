namespace Restaurant.Qualite;

public class ServiceCommandes
{
    private readonly INotificationCommande m_notification;
    private Commande? m_derniereCommande;

    public ServiceCommandes(INotificationCommande notification)
    {
        m_notification = notification ?? throw new ArgumentNullException(nameof(notification));
    }

    public Commande Creer(int numero, decimal sousTotal, Client client)
    {
        Commande commande = new(numero, sousTotal, sousTotal * 0.14975m, client);
        m_derniereCommande = commande;
        m_notification.NotifierCreation(
            commande.Numero,
            commande.Client.Profil.Coordonnees.Courriel);
        return commande;
    }

    public Commande? ObtenirDerniereCommande()
    {
        return m_derniereCommande;
    }
}
