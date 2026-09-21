using Moq;
using Restaurant.Qualite;

namespace Restaurant.Qualite.Tests;

public class ServiceCommandesTests
{
    [Fact]
    public void Creer_CommandeValide_NotifieAvecEspionManuel()
    {
        EspionNotificationCommande notification = new();
        ServiceCommandes service = new(notification, new CalculateurTaxe());

        service.Creer(1001, 40m, new Client("client@exemple.ca"));

        Assert.Equal(1001, notification.DernierNumero);
        Assert.Equal("client@exemple.ca", notification.DernierCourriel);
    }

    [Fact]
    public void Creer_CommandeValide_NotifieAvecMoq()
    {
        Mock<INotificationCommande> notification = new();
        ServiceCommandes service = new(notification.Object, new CalculateurTaxe());

        service.Creer(1001, 40m, new Client("client@exemple.ca"));

        notification.Verify(
            port => port.NotifierCreation(1001, "client@exemple.ca"),
            Times.Once);
        notification.VerifyNoOtherCalls();
    }

    private sealed class EspionNotificationCommande : INotificationCommande
    {
        public int? DernierNumero { get; private set; }
        public string? DernierCourriel { get; private set; }

        public void NotifierCreation(int numeroCommande, string courriel)
        {
            DernierNumero = numeroCommande;
            DernierCourriel = courriel;
        }
    }
}
