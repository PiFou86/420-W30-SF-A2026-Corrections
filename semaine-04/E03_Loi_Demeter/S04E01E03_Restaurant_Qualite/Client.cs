namespace Restaurant.Qualite;

public class Client
{
    private readonly ProfilClient m_profil;

    public Client(string courriel)
    {
        m_profil = new ProfilClient(courriel);
    }

    public string ObtenirCourrielNotification()
    {
        return m_profil.ObtenirCourriel();
    }
}
