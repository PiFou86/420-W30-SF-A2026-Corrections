namespace Restaurant.Qualite;

internal class ProfilClient
{
    private readonly Coordonnees m_coordonnees;

    public ProfilClient(string courriel)
    {
        m_coordonnees = new Coordonnees(courriel);
    }

    public string ObtenirCourriel()
    {
        return m_coordonnees.Courriel;
    }
}
