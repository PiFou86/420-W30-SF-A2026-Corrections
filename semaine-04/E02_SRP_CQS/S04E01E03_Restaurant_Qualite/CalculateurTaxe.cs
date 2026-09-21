namespace Restaurant.Qualite;

public class CalculateurTaxe
{
    private const decimal Taux = 0.14975m;

    public decimal Calculer(decimal sousTotal)
    {
        return sousTotal * Taux;
    }
}
