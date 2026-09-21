using Restaurant;

internal static class Program
{
    public static void Main(string[] args)
    {
        INotificationCommande notification = new NotificationConsole();
        ServiceCommandes service = new(notification);
        service.Creer(1001);
    }
}
