# Commandes `dotnet` équivalentes

L'exercice demande de créer la solution dans Visual Studio. Les commandes
suivantes réalisent les mêmes opérations avec le SDK .NET 10 :

```bash
mkdir S02E01_Restaurant_Commande
cd S02E01_Restaurant_Commande

dotnet new sln -n S02E01_Restaurant_Commande
dotnet new classlib -n S02E01_Restaurant_Commande -f net10.0
dotnet new xunit -n S02E01_Restaurant_Commande.Tests -f net10.0

dotnet sln S02E01_Restaurant_Commande.slnx add S02E01_Restaurant_Commande/S02E01_Restaurant_Commande.csproj
dotnet sln S02E01_Restaurant_Commande.slnx add S02E01_Restaurant_Commande.Tests/S02E01_Restaurant_Commande.Tests.csproj

dotnet add S02E01_Restaurant_Commande.Tests/S02E01_Restaurant_Commande.Tests.csproj reference S02E01_Restaurant_Commande/S02E01_Restaurant_Commande.csproj
dotnet add S02E01_Restaurant_Commande.Tests/S02E01_Restaurant_Commande.Tests.csproj package Moq --version 4.20.72

dotnet restore
dotnet build
dotnet test
```

## Correspondances avec Visual Studio

- `dotnet new` applique un modèle de solution ou de projet.
- `dotnet sln ... add` ajoute un projet à la solution.
- `dotnet add ... reference` crée un `ProjectReference` vers un autre projet.
- `dotnet add ... package` crée un `PackageReference` vers un paquet NuGet.

Avec le SDK .NET 10, `dotnet new sln` crée normalement un fichier `.slnx`. Pour
demander explicitement l'ancien format `.sln`, utilisez plutôt :

```bash
dotnet new sln -n S02E01_Restaurant_Commande --format sln
```
