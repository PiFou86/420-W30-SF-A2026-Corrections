# Exercice 3 — Correction

La classe `ServiceCommandes` appelle désormais la méthode
`Client.ObtenirCourrielNotification()` sur son collaborateur direct. Les
classes `ProfilClient` et `Coordonnees` restent des détails internes au client.

Les deux tests d’interaction de l’exercice 1 demeurent inchangés et servent de
tests de caractérisation : la notification observable est préservée. Le seul
nouveau test vérifie le message métier `Client.ObtenirCourrielNotification()`.

Cet état conserve aussi les acquis de l'exercice 2 : `Creer` demeure une
commande sans valeur de retour, `ObtenirDerniereCommande` demeure une requête
et `Commande` conserve son sous-total.

Le projet de tests conserve les deux tests de notification de l’exercice 1 et
les deux tests de taxe et de CQS de l’exercice 2, auxquels s’ajoute le test du
message métier introduit pour la loi de Déméter.
