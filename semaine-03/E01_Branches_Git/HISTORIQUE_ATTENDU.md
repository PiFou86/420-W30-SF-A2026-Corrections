# Historique attendu

Le résultat exact des identifiants de commits varie, mais le graphe doit
montrer :

1. une branche `exercice/premiere-branche` publiée;
2. une branche `exercice/distance` créée dans GitHub puis suivie localement;
3. la fusion sans conflit de `exercice/premiere-branche` dans `main`;
4. deux branches `exercice/conflit-a` et `exercice/conflit-b` issues du même
   point et modifiant la même ligne;
5. un commit de résolution après la seconde fusion;
6. un état final propre selon `git status`.

Une résolution possible conserve les deux intentions dans une seule phrase :

```text
Messages choisis dans A et B
```

Il ne doit rester aucun marqueur `<<<<<<<`, `=======` ou `>>>>>>>`.
