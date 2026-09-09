namespace ValidationRestaurant;

public sealed class AvertisseurCuisine
{
    private readonly IExpediteurMessage m_expediteurMessage;

    public AvertisseurCuisine(IExpediteurMessage expediteurMessage)
    {
        ArgumentNullException.ThrowIfNull(expediteurMessage);
        m_expediteurMessage = expediteurMessage;
    }

    public void AvertirCommandePrete(string numeroCommande)
    {
        if (string.IsNullOrWhiteSpace(numeroCommande))
        {
            throw new ArgumentException(
                "Le numéro de commande est obligatoire.",
                nameof(numeroCommande));
        }

        m_expediteurMessage.Envoyer(
            $"La commande {numeroCommande} est prête.");
    }
}
