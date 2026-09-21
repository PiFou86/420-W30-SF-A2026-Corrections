namespace Restaurant.Qualite;

public class ServiceCommandes
{
    private readonly INotificationCommande m_notification;
    private readonly CalculateurTaxe m_calculateurTaxe;
    private Commande? m_derniereCommande;

    public ServiceCommandes(INotificationCommande notification, CalculateurTaxe calculateurTaxe)
    {
        m_notification = notification ?? throw new ArgumentNullException(nameof(notification));
        m_calculateurTaxe = calculateurTaxe ?? throw new ArgumentNullException(nameof(calculateurTaxe));
    }

    public void Creer(int numero, decimal sousTotal, Client client)
    {
        Commande commande = new(numero, sousTotal, m_calculateurTaxe.Calculer(sousTotal), client);
        m_derniereCommande = commande;
        m_notification.NotifierCreation(numero, client.ObtenirCourrielNotification());
    }

    public Commande? ObtenirDerniereCommande()
    {
        return m_derniereCommande;
    }
}
