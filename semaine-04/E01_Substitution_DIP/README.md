# Exercice 1 — Correction

La classe `ServiceCommandes` dépend maintenant de l’interface
`INotificationCommande`. L'assemblage concret demeure dans le fichier
`Program.cs` du projet Terminal. La première composition est manuelle; la
seconde utilise `HostApplicationBuilder`, une inscription `Scoped` et une
portée explicite. Le même scénario est testé dans le projet de tests avec un
espion manuel, puis avec Moq sans résoudre le service depuis le conteneur.

La donnée membre `m_derniereCommande` et la méthode
`ObtenirDerniereCommande()` du projet de départ sont conservées : cet état ne
retire aucun comportement qui n’est pas visé par l’exercice 1.

## Question de transfert

- `INotificationCommande` rend le moyen de notification interchangeable.
- `Program.cs`, le point de composition, choisit `NotificationConsole`.
- `ServiceCommandes` conserve son orchestration et son appel au contrat lorsque
  l'implantation change.
- `ServiceCommandes` et `NotificationConsole` sont `Scoped` : les objets du cas
  d’utilisation vivent dans la portée de l’opération.
- l’espion expose directement l’état observé; Moq exprime la même vérification
  avec moins de code de doublure.
