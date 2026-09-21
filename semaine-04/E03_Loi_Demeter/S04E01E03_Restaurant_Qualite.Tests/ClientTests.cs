using Restaurant.Qualite;

namespace Restaurant.Qualite.Tests;

public class ClientTests
{
    [Fact]
    public void ObtenirCourrielNotification_ClientValide_RetourneCourriel()
    {
        Client client = new("client@exemple.ca");

        string courriel = client.ObtenirCourrielNotification();

        Assert.Equal("client@exemple.ca", courriel);
    }
}
