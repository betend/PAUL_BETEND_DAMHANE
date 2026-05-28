using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Produit
    {
        private int produit_id;
        private bool est_indisponible;
        private int nb_parts;
        private decimal prix;

        public int Produit_id
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

        public bool Est_indisponible
        {
            get
            {
                return this.est_indisponible;
            }

            set
            {
                this.est_indisponible = value;
            }
        }

        public int Nb_parts
        {
            get
            {
                return this.nb_parts;
            }

            set
            {
                this.nb_parts = value;
            }
        }

        public decimal Prix
        {
            get
            {
                return this.prix;
            }

            set
            {
                this.prix = value;
            }
        }
    }
}
