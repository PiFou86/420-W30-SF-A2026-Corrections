using Moq;
using Restaurant;

namespace Restaurant.Tests;

public sealed class ServiceFinalisationCommandeTests
{
    [Fact]
    public void Finaliser_CommandeValide_ConfirmeEtEnvoieLaCommande()
    {
        // Arranger
        Commande commande = CreerCommandeDeuxLignes();
        Mock<IDisponibilitePlats> disponibilite =
            new Mock<IDisponibilitePlats>();
        Mock<IPasserellePaiement> paiement =
            new Mock<IPasserellePaiement>();
        Mock<IExpediteurCuisine> expediteur =
            new Mock<IExpediteurCuisine>();

        disponibilite
            .Setup(objet => objet.EstDisponible("POU-01", 2))
            .Returns(true);
        disponibilite
            .Setup(objet => objet.EstDisponible("SOU-02", 1))
            .Returns(true);
        paiement
            .Setup(objet => objet.Autoriser("C-1042", 30.00m))
            .Returns(true);

        ServiceFinalisationCommande service =
            new ServiceFinalisationCommande(
                disponibilite.Object,
                paiement.Object,
                expediteur.Object);

        // Agir
        ResultatFinalisationCommande resultat = service.Finaliser(commande);

        // Auditer
        Assert.Equal(
            ResultatFinalisationCommande.CommandeConfirmee,
            resultat);
        disponibilite.Verify(
            objet => objet.EstDisponible("POU-01", 2),
            Times.Once);
        disponibilite.Verify(
            objet => objet.EstDisponible("SOU-02", 1),
            Times.Once);
        paiement.Verify(
            objet => objet.Autoriser(
                "C-1042",
                It.Is<decimal>(montant => montant == 30.00m)),
            Times.Once);
        expediteur.Verify(
            objet => objet.Envoyer("C-1042", 3, 30.00m),
            Times.Once);

        disponibilite.VerifyNoOtherCalls();
        paiement.VerifyNoOtherCalls();
        expediteur.VerifyNoOtherCalls();
    }

    [Fact]
    public void Finaliser_PremierPlatIndisponible_ArreteAvantPaiement()
    {
        // Arranger
        Commande commande = CreerCommandeDeuxLignes();
        Mock<IDisponibilitePlats> disponibilite =
            new Mock<IDisponibilitePlats>();
        Mock<IPasserellePaiement> paiement =
            new Mock<IPasserellePaiement>();
        Mock<IExpediteurCuisine> expediteur =
            new Mock<IExpediteurCuisine>();

        disponibilite
            .Setup(objet => objet.EstDisponible("POU-01", 2))
            .Returns(false);

        ServiceFinalisationCommande service =
            new ServiceFinalisationCommande(
                disponibilite.Object,
                paiement.Object,
                expediteur.Object);

        // Agir
        ResultatFinalisationCommande resultat = service.Finaliser(commande);

        // Auditer
        Assert.Equal(
            ResultatFinalisationCommande.PlatIndisponible,
            resultat);
        disponibilite.Verify(
            objet => objet.EstDisponible("POU-01", 2),
            Times.Once);
        disponibilite.Verify(
            objet => objet.EstDisponible("SOU-02", 1),
            Times.Never);
        paiement.Verify(
            objet => objet.Autoriser(
                It.IsAny<string>(),
                It.IsAny<decimal>()),
            Times.Never);
        expediteur.Verify(
            objet => objet.Envoyer(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<decimal>()),
            Times.Never);

        disponibilite.VerifyNoOtherCalls();
        paiement.VerifyNoOtherCalls();
        expediteur.VerifyNoOtherCalls();
    }

    [Fact]
    public void Finaliser_PaiementRefuse_NEnvoiePasLaCommande()
    {
        // Arranger
        Commande commande = CreerCommandeDeuxLignes();
        Mock<IDisponibilitePlats> disponibilite =
            new Mock<IDisponibilitePlats>();
        Mock<IPasserellePaiement> paiement =
            new Mock<IPasserellePaiement>();
        Mock<IExpediteurCuisine> expediteur =
            new Mock<IExpediteurCuisine>();

        disponibilite
            .Setup(objet => objet.EstDisponible("POU-01", 2))
            .Returns(true);
        disponibilite
            .Setup(objet => objet.EstDisponible("SOU-02", 1))
            .Returns(true);
        paiement
            .Setup(objet => objet.Autoriser("C-1042", 30.00m))
            .Returns(false);

        ServiceFinalisationCommande service =
            new ServiceFinalisationCommande(
                disponibilite.Object,
                paiement.Object,
                expediteur.Object);

        // Agir
        ResultatFinalisationCommande resultat = service.Finaliser(commande);

        // Auditer
        Assert.Equal(ResultatFinalisationCommande.PaiementRefuse, resultat);
        disponibilite.Verify(
            objet => objet.EstDisponible("POU-01", 2),
            Times.Once);
        disponibilite.Verify(
            objet => objet.EstDisponible("SOU-02", 1),
            Times.Once);
        paiement.Verify(
            objet => objet.Autoriser("C-1042", 30.00m),
            Times.Once);
        expediteur.Verify(
            objet => objet.Envoyer(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<decimal>()),
            Times.Never);

        disponibilite.VerifyNoOtherCalls();
        paiement.VerifyNoOtherCalls();
        expediteur.VerifyNoOtherCalls();
    }

    [Fact]
    public void Finaliser_CommandeVide_LanceExceptionSansInteraction()
    {
        // Arranger
        Commande commande = new Commande("C-1042");
        Mock<IDisponibilitePlats> disponibilite =
            new Mock<IDisponibilitePlats>();
        Mock<IPasserellePaiement> paiement =
            new Mock<IPasserellePaiement>();
        Mock<IExpediteurCuisine> expediteur =
            new Mock<IExpediteurCuisine>();
        ServiceFinalisationCommande service =
            new ServiceFinalisationCommande(
                disponibilite.Object,
                paiement.Object,
                expediteur.Object);

        // Agir
        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(
                () => service.Finaliser(commande));

        // Auditer
        Assert.Equal(
            "Une commande vide ne peut pas être finalisée.",
            exception.Message);
        disponibilite.Verify(
            objet => objet.EstDisponible(
                It.IsAny<string>(),
                It.IsAny<int>()),
            Times.Never);
        paiement.Verify(
            objet => objet.Autoriser(
                It.IsAny<string>(),
                It.IsAny<decimal>()),
            Times.Never);
        expediteur.Verify(
            objet => objet.Envoyer(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<decimal>()),
            Times.Never);

        disponibilite.VerifyNoOtherCalls();
        paiement.VerifyNoOtherCalls();
        expediteur.VerifyNoOtherCalls();
    }

    private static Commande CreerCommandeDeuxLignes()
    {
        Commande commande = new Commande("C-1042");
        commande.AjouterLigne(
            new LigneCommande("POU-01", "Poutine", 12.00m, 2, 0m));
        commande.AjouterLigne(
            new LigneCommande("SOU-02", "Soupe", 6.00m, 1, 0m));
        return commande;
    }
}
