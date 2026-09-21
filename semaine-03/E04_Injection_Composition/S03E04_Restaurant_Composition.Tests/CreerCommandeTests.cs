using Restaurant.Application;

namespace Restaurant.Tests;

public sealed class CreerCommandeTests
{
    [Fact]
    public void Executer_NumeroValide_AjouteEtNotifieLaCommande()
    {
        // Arranger
        DepotCommandesMemoire depot = new();
        NotificationCommandeMemoire notification = new();
        CreerCommande creerCommande = new(depot, notification);

        // Agir
        creerCommande.Executer(1001);

        // Auditer
        Assert.Equal(1001, depot.DerniereCommande?.Numero);
        Assert.Equal(1001, notification.DernierNumeroCommande);
    }
}
