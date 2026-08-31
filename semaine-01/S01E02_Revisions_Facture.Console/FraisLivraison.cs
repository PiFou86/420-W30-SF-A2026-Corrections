using System;
using System.Collections.Generic;
using System.Text;

namespace S01E02_Revisions_Facture_Console
{
    public class FraisLivraison : ILigneFacturable
    {
        public string Description => "Frais de livraison";
        public decimal PrixUnitaire { get; }

        public int Quantite { get; }

        public decimal Total => Quantite * PrixUnitaire;

        public FraisLivraison(decimal tarifParKm, int distanceKm)
        {
            PrixUnitaire = tarifParKm;
            Quantite = distanceKm;
        }

        public override string ToString()
        {
            return $"| {Description,-30} | {Quantite,3} km | {PrixUnitaire,15:C} | {Total,20:C} |";
        }
    }
}
