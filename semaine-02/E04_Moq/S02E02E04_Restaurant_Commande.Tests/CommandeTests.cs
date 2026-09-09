using Restaurant;

namespace Restaurant.Tests;

public sealed class CommandeTests
{
    [Fact]
    public void NouvelleCommande_AucuneLigne_EstVideAvecTotauxZero()
    {
        // Arranger
        Commande commande = new Commande("C-1042");

        // Agir
        bool estVide = commande.EstVide;
        decimal sousTotal = commande.SousTotal;
        int nombreArticles = commande.NombreArticles;

        // Auditer
        Assert.True(estVide);
        Assert.Equal(0.00m, sousTotal);
        Assert.Equal(0, nombreArticles);
    }

    [Fact]
    public void Totaux_LigneAvecRabais_RetournentMontantsNetsAttendus()
    {
        // Arranger
        Commande commande = new Commande("C-1042");
        commande.AjouterLigne(
            new LigneCommande("POU-01", "Poutine", 14.50m, 2, 10m));
        commande.AjouterLigne(
            new LigneCommande("SOU-01", "Soupe", 6.00m, 1, 0m));

        // Agir
        decimal sousTotal = commande.SousTotal;
        int nombreArticles = commande.NombreArticles;

        // Auditer
        Assert.False(commande.EstVide);
        Assert.Equal(32.10m, sousTotal);
        Assert.Equal(3, nombreArticles);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructeur_NumeroVide_LanceArgumentException(string numero)
    {
        // Agir
        ArgumentException exception = Assert.Throws<ArgumentException>(
            () => new Commande(numero));

        // Auditer
        Assert.Equal("numero", exception.ParamName);
    }

    [Fact]
    public void AjouterLigne_LigneNull_LanceArgumentNullException()
    {
        // Arranger
        Commande commande = new Commande("C-1042");

        // Agir
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => commande.AjouterLigne(null!));

        // Auditer
        Assert.Equal("ligne", exception.ParamName);
    }
}
