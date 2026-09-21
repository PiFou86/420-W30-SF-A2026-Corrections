# Exercice 2 — Correction

La classe `CalculateurTaxe` possède sa propre responsabilité. La méthode de
commande `Creer` produit un effet sans retourner de valeur, tandis que la
méthode de requête `ObtenirDerniereCommande` observe l'état sans le modifier.

Les compositions manuelle et automatisée fournissent maintenant le
`CalculateurTaxe`. Le cadriciel connaît les types concrets; le service ne dépend
toujours que des collaborateurs reçus par son constructeur.

La chaîne publique `Client → ProfilClient → Coordonnees` demeure volontairement
inchangée à cette étape : son réusinage appartient à l’exercice 3. Le projet de
tests conserve également les deux tests d’interaction de l’exercice 1.
