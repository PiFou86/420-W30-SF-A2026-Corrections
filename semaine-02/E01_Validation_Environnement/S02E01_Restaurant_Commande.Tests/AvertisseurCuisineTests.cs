using Moq;
using ValidationRestaurant;

namespace ValidationRestaurant.Tests;

public sealed class AvertisseurCuisineTests
{
    [Fact]
    public void AvertirCommandePrete_NumeroValide_EnvoieLeMessageUneFois()
    {
        // Arranger
        Mock<IExpediteurMessage> expediteur = new Mock<IExpediteurMessage>();
        AvertisseurCuisine avertisseur =
            new AvertisseurCuisine(expediteur.Object);

        // Agir
        avertisseur.AvertirCommandePrete("C-1042");

        // Auditer
        expediteur.Verify(
            objet => objet.Envoyer("La commande C-1042 est prête."),
            Times.Once);
        expediteur.VerifyNoOtherCalls();
    }

    [Fact]
    public void Constructeur_ExpediteurNull_LanceArgumentNullException()
    {
        // Agir
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new AvertisseurCuisine(null!));

        // Auditer
        Assert.Equal("expediteurMessage", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void AvertirCommandePrete_NumeroVide_LanceArgumentException(
        string numeroCommande)
    {
        // Arranger
        Mock<IExpediteurMessage> expediteur = new Mock<IExpediteurMessage>();
        AvertisseurCuisine avertisseur =
            new AvertisseurCuisine(expediteur.Object);

        // Agir
        ArgumentException exception = Assert.Throws<ArgumentException>(
            () => avertisseur.AvertirCommandePrete(numeroCommande));

        // Auditer
        Assert.Equal("numeroCommande", exception.ParamName);
        expediteur.Verify(
            objet => objet.Envoyer(It.IsAny<string>()),
            Times.Never);
        expediteur.VerifyNoOtherCalls();
    }
}
