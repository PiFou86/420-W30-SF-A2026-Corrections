namespace Restaurant.Qualite;

public class ProfilClient
{
    public Coordonnees Coordonnees { get; }

    public ProfilClient(string courriel)
    {
        Coordonnees = new Coordonnees(courriel);
    }
}
