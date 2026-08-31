using System;
using System.Collections.Generic;
using System.Text;

namespace S01E02_Revisions_Facture_Console
{
    public interface ILigneFacturable
    {
        public string Description { get;}
        public decimal PrixUnitaire { get; }
        public int Quantite { get; }
        public decimal Total { get; }
    }
}
