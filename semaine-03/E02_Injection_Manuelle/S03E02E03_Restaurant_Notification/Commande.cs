namespace Restaurant;

public sealed class Commande
{
    public Commande(int numero)
    {
        if (numero <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numero));
        }

        Numero = numero;
    }

    public int Numero { get; }
}
