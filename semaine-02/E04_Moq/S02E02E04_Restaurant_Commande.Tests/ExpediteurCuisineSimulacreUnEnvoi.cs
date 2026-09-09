using Restaurant;
using Xunit.Sdk;

namespace Restaurant.Tests;

public sealed class ExpediteurCuisineSimulacreUnEnvoi : IExpediteurCuisine
{
    private readonly string m_numeroAttendu;
    private readonly int m_nombreArticlesAttendu;
    private readonly decimal m_montantAttendu;
    private int m_nombreAppelsEnvoyer;
    private string? m_numeroDernierAppelEnvoyer;
    private int m_nombreArticlesDernierAppelEnvoyer;
    private decimal m_montantDernierAppelEnvoyer;

    public ExpediteurCuisineSimulacreUnEnvoi(
        string numeroAttendu,
        int nombreArticlesAttendu,
        decimal montantAttendu)
    {
        if (string.IsNullOrWhiteSpace(numeroAttendu))
        {
            throw new ArgumentException(
                "Le numéro attendu est obligatoire.",
                nameof(numeroAttendu));
        }

        if (nombreArticlesAttendu < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nombreArticlesAttendu));
        }

        if (montantAttendu < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(montantAttendu));
        }

        m_numeroAttendu = numeroAttendu;
        m_nombreArticlesAttendu = nombreArticlesAttendu;
        m_montantAttendu = montantAttendu;
    }

    public void Envoyer(
        string numeroCommande,
        int nombreArticles,
        decimal montantTotal)
    {
        m_nombreAppelsEnvoyer++;
        m_numeroDernierAppelEnvoyer = numeroCommande;
        m_nombreArticlesDernierAppelEnvoyer = nombreArticles;
        m_montantDernierAppelEnvoyer = montantTotal;
    }

    public void VerifierAttentes()
    {
        if (m_nombreAppelsEnvoyer != 1)
        {
            throw EqualException.ForMismatchedValues(
                1,
                m_nombreAppelsEnvoyer,
                "Envoyer devait être appelée exactement une fois.");
        }

        if (m_numeroAttendu != m_numeroDernierAppelEnvoyer)
        {
            throw EqualException.ForMismatchedValues(
                m_numeroAttendu,
                m_numeroDernierAppelEnvoyer,
                "Le numéro de commande du dernier appel à Envoyer est incorrect.");
        }

        if (m_nombreArticlesAttendu != m_nombreArticlesDernierAppelEnvoyer)
        {
            throw EqualException.ForMismatchedValues(
                m_nombreArticlesAttendu,
                m_nombreArticlesDernierAppelEnvoyer,
                "Le nombre d'articles du dernier appel à Envoyer est incorrect.");
        }

        if (m_montantAttendu != m_montantDernierAppelEnvoyer)
        {
            throw EqualException.ForMismatchedValues(
                m_montantAttendu,
                m_montantDernierAppelEnvoyer,
                "Le montant du dernier appel à Envoyer est incorrect.");
        }
    }
}
