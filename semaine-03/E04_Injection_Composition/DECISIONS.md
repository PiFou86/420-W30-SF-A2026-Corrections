# Décisions

## Cycle de vie choisi

`CreerCommande`, `IDepotCommandes` et `INotificationCommande` sont enregistrés
avec `AddScoped`. Une portée représente ici une opération de création. Le dépôt
mémoire conserve son état pendant cette opération et aucune instance n'est
partagée globalement.

## Historique Git attendu

Le graphe doit montrer `fonctionnalite/exercice-4-injection` fusionnée dans `dev`,
puis `dev` fusionnée dans `main`. Les identifiants de commits varient selon la
réalisation.
