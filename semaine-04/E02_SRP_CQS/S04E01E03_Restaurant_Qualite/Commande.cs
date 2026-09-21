namespace Restaurant.Qualite;

public class Commande
{
    public int Numero { get; }
    public decimal SousTotal { get; }
    public decimal Taxe { get; }
    public Client Client { get; }

    public Commande(int numero, decimal sousTotal, decimal taxe, Client client)
    {
        Numero = numero;
        SousTotal = sousTotal;
        Taxe = taxe;
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }
}
