using Npgsql;
using PAUL_BETEND_DAMHANE.Model;
using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_BETEND_DAMHANE
{
    public class LigneCommande: ICrud<LigneCommande>
    {
        private int ligne_commande_id;
        private int commande_id;
        private int produit_id;
        private int quantite;
        private bool est_decoupe;
        private decimal sous_total;
        private Produit unProduit;

        public LigneCommande()
        {
        }

        public LigneCommande(Int32 commande_id, Int32 produit_id, Int32 quantite, bool est_decoupe)
        {
            this.Commande_id = commande_id;
            this.Produit_id = produit_id;
            this.Quantite = quantite;
            this.Est_decoupe = est_decoupe;
        }

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
                return this.Quantite * this.UnProduit.Prix;
            }

            set
            {
                this.sous_total = value;
            }
        }

        public Produit UnProduit
        {
            get
            {
                return this.unProduit;
            }

            set
            {
                this.unProduit = value;
            }
        }


        public Int32 Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into chiens (commande_id,produit_id,quantite, est_decoupe  ) values (@commande_id,@produit_id,@quantite, @est_decoupe) RETURNING commande_id"))
            {
                cmdInsert.Parameters.AddWithValue("commande_id", this.Commande_id);
                cmdInsert.Parameters.AddWithValue("produit_id", this.Produit_id);
                cmdInsert.Parameters.AddWithValue("quantite", this.Quantite);
                cmdInsert.Parameters.AddWithValue("est_decoupe", this.Est_decoupe);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.Ligne_commande_id = nb;
            return nb;
        }

        public Int32 Delete()
        {
            throw new NotImplementedException();
        }

        public List<LigneCommande> FindAll()
        {
            List<LigneCommande> lesLignesCommande = new List<LigneCommande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from ligne_commande ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesLignesCommande.Add(new LigneCommande((int)dr["commande_id"], (int)dr["produit_id"],
                   (int)dr["quantite"], (bool)dr["est_decoupe"]));
            }
            return lesLignesCommande;
        }

        public List<LigneCommande> FindBySelection(String criteres)
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
