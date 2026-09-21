using Restaurant.Application;
using Restaurant.Domaine;

namespace Restaurant.Infrastructure;

public sealed class DepotCommandesMemoire : IDepotCommandes
{
    private readonly List<Commande> m_commandes = [];

    public IReadOnlyList<Commande> Commandes
    {
        get
        {
            return m_commandes.AsReadOnly();
        }
    }

    public void Ajouter(Commande commande)
    {
        ArgumentNullException.ThrowIfNull(commande);
        m_commandes.Add(commande);
    }
}
