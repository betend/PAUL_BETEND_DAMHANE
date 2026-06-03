using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_BETEND_DAMHANE
{
    public class LigneCommande
    {
        private int ligne_commande_id;
        private int commande_id;
        private int produit_id;
        private int quantite;
        private bool est_decoupe;
        private decimal sous_total;

        public Int32 Ligne_commande_id
        {
            get
            {
                return this.ligne_commande_id;
            }

            set
            {
                this.ligne_commande_id = value;
            }
        }

        public Int32 Commande_id
        {
            get
            {
                return this.commande_id;
            }

            set
            {
                this.commande_id = value;
            }
        }

        public Int32 Produit_id
        {
            get
            {
                return this.produit_id;
            }

            set
            {
                this.produit_id = value;
            }
        }

        public Int32 Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                this.quantite = value;
            }
        }

        public Boolean Est_decoupe
        {
            get
            {
                return this.est_decoupe;
            }

            set
            {
                this.est_decoupe = value;
            }
        }

        public Decimal Sous_total
        {
            get
            {
                return this.sous_total;
            }

            set
            {
                this.sous_total = value;
            }
        }
    }
}
