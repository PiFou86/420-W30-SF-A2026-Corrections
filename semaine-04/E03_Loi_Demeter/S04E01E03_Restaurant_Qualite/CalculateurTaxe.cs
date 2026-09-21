namespace Restaurant.Qualite;

public class CalculateurTaxe
{
    public decimal Calculer(decimal sousTotal)
    {
        return sousTotal * 0.14975m;
    }
}
