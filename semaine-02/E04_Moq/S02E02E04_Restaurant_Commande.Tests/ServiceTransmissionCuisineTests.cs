using Restaurant;

namespace Restaurant.Tests;

public sealed class ServiceTransmissionCuisineTests
{
    [Fact]
    public void Transmettre_CommandeValide_EnvoieLesValeursExactesUneFois()
    {
        // Arranger
        Commande commande = CreerCommandeValide();
        ExpediteurCuisineSimulacreUnEnvoi expediteur =
            new ExpediteurCuisineSimulacreUnEnvoi("C-1042", 3, 35.00m);
        ServiceTransmissionCuisine service =
            new ServiceTransmissionCuisine(expediteur);

        // Agir
        service.Transmettre(commande);

        // Auditer
        expediteur.VerifierAttentes();
    }

    [Fact]
    public void Transmettre_CommandeVide_LanceExceptionSansEnvoyer()
    {
        // Arranger
        Commande commande = new Commande("C-1042");
        ExpediteurCuisineSimulacreAucunEnvoi expediteur = new();
        ServiceTransmissionCuisine service =
            new ServiceTransmissionCuisine(expediteur);

        // Agir
        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(
                () => service.Transmettre(commande));

        // Auditer
        Assert.Equal(
            "Une commande vide ne peut pas être transmise.",
            exception.Message);
        expediteur.VerifierAttentes();
    }

    [Fact]
    public void Transmettre_CommandeNull_LanceExceptionSansEnvoyer()
    {
        // Arranger
        ExpediteurCuisineSimulacreAucunEnvoi expediteur = new();
        ServiceTransmissionCuisine service =
            new ServiceTransmissionCuisine(expediteur);

        // Agir
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => service.Transmettre(null!));

        // Auditer
        Assert.Equal("commande", exception.ParamName);
        expediteur.VerifierAttentes();
    }

    private static Commande CreerCommandeValide()
    {
        Commande commande = new Commande("C-1042");
        commande.AjouterLigne(
            new LigneCommande("POU-01", "Poutine", 14.50m, 2, 0m));
        commande.AjouterLigne(
            new LigneCommande("SOU-01", "Soupe", 6.00m, 1, 0m));
        return commande;
    }
}
