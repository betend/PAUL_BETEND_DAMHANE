using Npgsql;
using PAUL_BETEND_DAMHANE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PAUL_DAMHANE_BETEND
{
    public class Produit: ICrud<Produit>
    {
        private int produit_id;
        private bool est_indisponible;
        private int nb_parts;
        private decimal prix;
        public ObservableCollection<Produit> lesProduits;

        public Produit()
        {
        }

        public Produit(Int32 produit_id, Boolean est_indisponible, Int32 nb_parts, Decimal prix)
        {
            this.Produit_id = produit_id;
            this.Est_indisponible = est_indisponible;
            this.Nb_parts = nb_parts;
            this.Prix = prix;
        }

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

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }

        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public List<Produit> FindAll()
        {
            List<Produit> lesProduits = new List<Produit>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from produit ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesProduits.Add(new Produit((int)dr["produit_id"],
                   (bool)dr["est_indisponible"], (int)dr["nb_parts"], (decimal)dr["prix"]));
            }
            return lesProduits;
        }

        public List<Produit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
