using Restaurant;

namespace Restaurant.Tests;

public sealed class LigneCommandeTests
{
    public static IEnumerable<object[]> CasCalculTotal
    {
        get
        {
            yield return new object[] { 10.00m, 1, 0.00m, 10.00m };
            yield return new object[] { 12.50m, 2, 10.00m, 22.50m };
            yield return new object[] { 3.25m, 4, 20.00m, 10.40m };
            yield return new object[] { 10.00m, 2, 100.00m, 0.00m };
        }
    }

    public static IEnumerable<object[]> RabaisInvalides
    {
        get
        {
            yield return new object[] { -0.01m };
            yield return new object[] { 100.01m };
        }
    }

    [Fact]
    public void Total_DeuxPlats_RetourneVingtNeufDollars()
    {
        // Arranger
        LigneCommande ligne =
            new LigneCommande("POU-01", "Poutine", 14.50m, 2, 0m);

        // Agir
        decimal total = ligne.Total;

        // Auditer
        Assert.Equal(29.00m, total);
    }

    [Theory]
    [MemberData(nameof(CasCalculTotal))]
    public void Total_DonneesValides_RetourneTotalAttendu(
        decimal prixUnitaire,
        int quantite,
        decimal pourcentageRabais,
        decimal totalAttendu)
    {
        // Arranger
        LigneCommande ligne = new LigneCommande(
            "PLAT-01",
            "Plat du jour",
            prixUnitaire,
            quantite,
            pourcentageRabais);

        // Agir
        decimal total = ligne.Total;

        // Auditer
        Assert.Equal(pourcentageRabais, ligne.PourcentageRabais);
        Assert.Equal(totalAttendu, total);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructeur_CodePlatVide_LanceArgumentException(
        string codePlat)
    {
        // Agir
        ArgumentException exception = Assert.Throws<ArgumentException>(
            () => new LigneCommande(codePlat, "Poutine", 14.50m, 1, 0m));

        // Auditer
        Assert.Equal("codePlat", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructeur_DescriptionVide_LanceArgumentException(
        string description)
    {
        // Agir
        ArgumentException exception = Assert.Throws<ArgumentException>(
            () => new LigneCommande("POU-01", description, 14.50m, 1, 0m));

        // Auditer
        Assert.Equal("description", exception.ParamName);
    }

    [Fact]
    public void Constructeur_PrixUnitaireNegatif_LanceArgumentOutOfRangeException()
    {
        // Agir
        ArgumentOutOfRangeException exception =
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new LigneCommande(
                    "POU-01", "Poutine", -0.01m, 1, 0m));

        // Auditer
        Assert.Equal("prixUnitaire", exception.ParamName);
    }

    [Fact]
    public void Constructeur_QuantiteZero_LanceArgumentOutOfRangeException()
    {
        // Agir
        ArgumentOutOfRangeException exception =
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new LigneCommande(
                    "POU-01", "Poutine", 14.50m, 0, 0m));

        // Auditer
        Assert.Equal("quantite", exception.ParamName);
    }

    [Theory]
    [MemberData(nameof(RabaisInvalides))]
    public void Constructeur_RabaisInvalide_LanceArgumentOutOfRangeException(
        decimal pourcentageRabais)
    {
        // Agir
        ArgumentOutOfRangeException exception =
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new LigneCommande(
                    "POU-01",
                    "Poutine",
                    14.50m,
                    1,
                    pourcentageRabais));

        // Auditer
        Assert.Equal("pourcentageRabais", exception.ParamName);
    }
}
