namespace S01E02_Revisions_Facture_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Facture facture = new Facture();
            facture.AjouterLigne(new PlatCommande("Pizza calzone", 20.00m, 2));
            facture.AjouterLigne(new PlatCommande("Pâtes Carbonara", 10.00m, 1));
            facture.AjouterLigne(new PlatCommande("Poutine Italienne", 12.00m, 3));
            facture.AjouterLigne(new FraisLivraison(0.5m, 23));

            Console.Out.WriteLine(facture.ToString());
        }
    }
}
