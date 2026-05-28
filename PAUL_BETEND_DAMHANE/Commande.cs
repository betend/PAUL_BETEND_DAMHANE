using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Commande
    {
        private int commande_id;
        private DateTime date_creation;
        private DateTime date_retrait;
        private decimal accompte;
        private bool est_prete;
        private bool est_recuperee;
        private decimal total;
        private DateTime date_evenement;
        private int nb_personne;

        public int Commande_id
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

        public DateTime Date_creation
        {
            get
            {
                return this.date_creation;
            }

            set
            {
                this.date_creation = value;
            }
        }

        public DateTime Date_retrait
        {
            get
            {
                return this.date_retrait;
            }

            set
            {
                this.date_retrait = value;
            }
        }

        public decimal Accompte
        {
            get
            {
                return this.accompte;
            }

            set
            {
                this.accompte = value;
            }
        }

        public bool Est_prete
        {
            get
            {
                return this.est_prete;
            }

            set
            {
                this.est_prete = value;
            }
        }

        public bool Est_recuperee
        {
            get
            {
                return this.est_recuperee;
            }

            set
            {
                this.est_recuperee = value;
            }
        }

        public decimal Total
        {
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
            }
        }

        public DateTime Date_evenement
        {
            get
            {
                return this.date_evenement;
            }

            set
            {
                this.date_evenement = value;
            }
        }

        public int Nb_personne
        {
            get
            {
                return this.nb_personne;
            }

            set
            {
                this.nb_personne = value;
            }
        }
    }
}
