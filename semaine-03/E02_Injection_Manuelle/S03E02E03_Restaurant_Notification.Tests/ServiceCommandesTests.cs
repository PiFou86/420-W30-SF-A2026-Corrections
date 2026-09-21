using Restaurant;

namespace Restaurant.Tests;

public sealed class ServiceCommandesTests
{
    [Fact]
    public void Creer_NumeroValide_NotifieLeNumeroCommande()
    {
        // Arranger
        NotificationCommandeMemoire notification = new();
        ServiceCommandes service = new(notification);

        // Agir
        service.Creer(1001);

        // Auditer
        Assert.Equal(1001, notification.DernierNumeroCommande);
    }
}
