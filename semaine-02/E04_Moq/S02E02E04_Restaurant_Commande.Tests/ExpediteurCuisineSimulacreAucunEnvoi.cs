using Restaurant;
using Xunit.Sdk;

namespace Restaurant.Tests;

public sealed class ExpediteurCuisineSimulacreAucunEnvoi : IExpediteurCuisine
{
    private int m_nombreAppelsEnvoyer;

    public void Envoyer(
        string numeroCommande,
        int nombreArticles,
        decimal montantTotal)
    {
        m_nombreAppelsEnvoyer++;
    }

    public void VerifierAttentes()
    {
        if (m_nombreAppelsEnvoyer != 0)
        {
            throw EqualException.ForMismatchedValues(
                0,
                m_nombreAppelsEnvoyer,
                "Envoyer ne devait jamais être appelée.");
        }
    }
}
