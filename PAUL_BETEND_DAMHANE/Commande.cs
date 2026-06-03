using PAUL_BETEND_DAMHANE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PAUL_DAMHANE_BETEND
{
    public class Commande : ICrud<Commande>
    {
        private int commande_id;
        private int client_id;
        private Client unClient;
        private CategorieEvenement uneCategorie_evenement;
        private int categorie_evenement_id;
        private DateOnly date_creation;
        private DateOnly date_retrait;
        private decimal acompte;
        private bool est_prete;
        private bool est_recuperee;
        private decimal total;
        private DateOnly date_evenement;
        private int nb_personne;
        private ObservableCollection<Commande> lesCommandes;

        public Commande()
        {
        }

        public Commande(Int32 commande_id, DateOnly date_creation, DateOnly date_retrait, decimal accompte, Boolean est_prete, Boolean est_recuperee, Decimal total, DateOnly date_evenement, Int32 nb_personne)
        {
            this.Commande_id = commande_id;
            
            this.Date_creation = date_creation;
            this.Date_retrait = date_retrait;
            this.Accompte = accompte;
            this.Est_prete = est_prete;
            this.Est_recuperee = est_recuperee;
            this.Total = total;
            this.Date_evenement = date_evenement;
            this.Nb_personne = nb_personne;
        }

        public Commande(Int32 commande_id, DateOnly date_creation, DateOnly date_retrait, Decimal accompte, Boolean est_prete, Boolean est_recuperee, Decimal total, DateOnly date_evenement, Int32 nb_personne, Int32 client_id, Int32 categorie_evenement_id) : this(commande_id, date_creation, date_retrait, accompte, est_prete, est_recuperee, total, date_evenement, nb_personne)
        {
            this.Client_id = client_id;
            this.Categorie_evenement_id = categorie_evenement_id;
        }

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

        public DateOnly Date_creation
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

        public DateOnly Date_retrait
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
                return this.acompte;
            }

            set
            {
                this.acompte = value;
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

        public DateOnly Date_evenement
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

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes = value;
            }
        }

        public Int32 Client_id
        {
            get
            {
                return this.client_id;
            }

            set
            {
                this.client_id = value;
            }
        }

        public Int32 Categorie_evenement_id
        {
            get
            {
                return this.categorie_evenement_id;
            }

            set
            {
                this.categorie_evenement_id = value;
            }
        }

        public Client UnClient
        {
            get
            {
                return this.unClient;
            }

            set
            {
                this.unClient = value;
            }
        }

        public CategorieEvenement UneCategorie_evenement
        {
            get
            {
                return this.uneCategorie_evenement;
            }

            set
            {
                this.uneCategorie_evenement = value;
            }
        }

        public Int32 Create()
        {
            throw new NotImplementedException();
        }

        public Int32 Delete()
        {
            throw new NotImplementedException();
        }

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commande ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande((int)dr["commande_id"],
                   (DateOnly)dr["date_creation"], (DateOnly)dr["date_retrait"], (decimal)dr["acompte"], (bool)dr["est_prete"], (bool)dr["est_recuperee"], (decimal)dr["total"], (DateOnly)dr["date_evenement"], (int)dr["nb_personne"], (int)dr["client_id"], (int)dr["categorie_evenement_id"]));
            }
            return lesCommandes;
        }

        public List<Commande> FindBySelection(String criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public Int32 Update()
        {
            throw new NotImplementedException();
        }
    }
}
