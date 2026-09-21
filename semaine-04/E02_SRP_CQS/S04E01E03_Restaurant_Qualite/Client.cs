namespace Restaurant.Qualite;

public class Client
{
    public ProfilClient Profil { get; }

    public Client(string courriel)
    {
        Profil = new ProfilClient(courriel);
    }
}
