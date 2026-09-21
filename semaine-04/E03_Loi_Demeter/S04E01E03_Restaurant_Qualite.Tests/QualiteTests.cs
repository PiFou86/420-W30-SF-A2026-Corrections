using Restaurant.Qualite;

namespace Restaurant.Qualite.Tests;

public class QualiteTests
{
    [Fact]
    public void Calculer_SousTotal40_RetourneTaxe()
    {
        CalculateurTaxe calculateur = new();

        decimal taxe = calculateur.Calculer(40m);

        Assert.Equal(5.99m, taxe);
    }

    [Fact]
    public void ObtenirDerniereCommande_ApresCreation_RetourneCommandeCreee()
    {
        ServiceCommandes service = new(new NotificationMuette(), new CalculateurTaxe());

        service.Creer(1001, 40m, new Client("client@exemple.ca"));
        Commande? obtenue = service.ObtenirDerniereCommande();

        Assert.NotNull(obtenue);
        Assert.Equal(1001, obtenue.Numero);
        Assert.Equal(40m, obtenue.SousTotal);
    }

    private sealed class NotificationMuette : INotificationCommande
    {
        public void NotifierCreation(int numeroCommande, string courriel)
        {
        }
    }
}
