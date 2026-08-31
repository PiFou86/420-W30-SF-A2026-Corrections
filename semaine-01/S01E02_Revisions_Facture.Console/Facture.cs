using System;
using System.Collections.Generic;
using System.Text;

namespace S01E02_Revisions_Facture_Console
{
    public class Facture
    {
        private List<ILigneFacturable> m_lignesFacture;
        public List<ILigneFacturable> Lignes => new List<ILigneFacturable>(m_lignesFacture);
        public decimal MontantTotal => m_lignesFacture.Sum(ligne => ligne.Total);

        public Facture()
        {
            this.m_lignesFacture = new List<ILigneFacturable>();
        }

        public void AjouterLigne(ILigneFacturable ligne)
        {
            m_lignesFacture.Add(ligne);
        }

        public override string ToString()
        {
            const string ligneTableauTrait = "+--------------------------------+--------+-----------------+----------------------+";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ligneTableauTrait);
            sb.AppendLine( "| Description                    |  Qté   |   Prix Unitaire |                Total |");
            sb.AppendLine(ligneTableauTrait);

            foreach (var ligne in m_lignesFacture)
            {
                sb.AppendLine(ligne.ToString());
            }
            sb.AppendLine(ligneTableauTrait);
            sb.AppendLine($"                                              Montant total | {MontantTotal,20:C2} |");
            sb.AppendLine($"                                                            +----------------------+");


            return sb.ToString();
        }
    }
}
