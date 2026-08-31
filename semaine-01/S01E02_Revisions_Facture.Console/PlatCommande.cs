using System;
using System.Collections.Generic;
using System.Text;

namespace S01E02_Revisions_Facture_Console
{
    public class PlatCommande : ILigneFacturable
    {
        public string Description { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public decimal Total => PrixUnitaire * Quantite;
        public PlatCommande(string nom, decimal prixUnitaire, int quantite)
        {
            Description = nom;
            PrixUnitaire = prixUnitaire;
            Quantite = quantite;
        }

        public override string ToString()
        {
            return $"| {Description,-30} | {Quantite,6} | {PrixUnitaire,15:C} | {Total,20:C} |";
        }
    }
}
