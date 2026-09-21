using Restaurant.Application;
using Restaurant.Domaine;

namespace Restaurant.Tests;

public sealed class DepotCommandesMemoire : IDepotCommandes
{
    public Commande? DerniereCommande { get; private set; }

    public void Ajouter(Commande commande)
    {
        DerniereCommande = commande;
    }
}
