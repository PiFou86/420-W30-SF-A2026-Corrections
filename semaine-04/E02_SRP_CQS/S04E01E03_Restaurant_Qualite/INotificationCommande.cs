namespace Restaurant.Qualite;

public interface INotificationCommande
{
    void NotifierCreation(int numeroCommande, string courriel);
}
