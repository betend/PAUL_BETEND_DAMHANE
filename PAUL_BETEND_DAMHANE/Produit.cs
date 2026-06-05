using Npgsql;
using PAUL_BETEND_DAMHANE.Model;
using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
 


namespace PAUL_DAMHANE_BETEND
{
    public class Produit: ICrud<Produit>
    {
        private int produit_id;
        private int recette_id;

        private Recette uneRecette;


        private bool est_indisponible;
        private int nb_parts;
        private decimal prix;
        public ObservableCollection<Produit> lesProduits;
        private ObservableCollection<Allergenes> lesAllergenes;
        private string allergeneTexte;
        public Produit()
        {
        }

        public Produit(Int32 produit_id, int recette_id, Boolean est_indisponible, Int32 nb_parts, Decimal prix)
        {
            this.Produit_id = produit_id;
            this.Recette_id = recette_id;
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

        public Recette UneRecette
        {
            get
            {
                return this.uneRecette;
            }

            set
            {
                this.uneRecette = value;
            }
        }

        public Int32 Recette_id
        {
            get
            {
                return this.recette_id;
            }

            set
            {
                this.recette_id = value;
            }
        }

        public ObservableCollection<Allergenes> LesAllergenes
        {
            get
            {
                return this.lesAllergenes;
            }

            set
            {
                this.lesAllergenes = value;
            }
        }

        public string AllergeneTexte

        {

            get

            {

                if (UneRecette == null || UneRecette.LesAllergenes == null || UneRecette.LesAllergenes.Count == 0)

                    return "";

                return string.Join(", ", UneRecette.LesAllergenes.Select(a => a.Allergene_nom));

            }

        }


        public Int32 Create()
        {
            // Requête SQL d'insertion qui retourne l'ID généré par la séquence serial
            string req = "INSERT INTO produit (prix, nb_parts, est_indisponible, recette_id) VALUES (@prix, @nb_parts, @est_indisponible, @recette_id) RETURNING produit_id;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(req))
            {
                cmd.Parameters.Add("@prix", NpgsqlTypes.NpgsqlDbType.Numeric).Value = this.Prix;
                cmd.Parameters.Add("@nb_parts", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.Nb_parts;
                cmd.Parameters.Add("@est_indisponible", NpgsqlTypes.NpgsqlDbType.Boolean).Value = this.Est_indisponible;

                // ID de la recette choisie dans le ComboBox
                // cmd.Parameters.Add("@recette_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.Recette_id;

                // On utilise ExecuteInsert de votre DataAccess pour récupérer l'ID
                int idInsere = DataAccess.ExecuteInsert(cmd);
                this.Produit_id = idInsere;

                return idInsere;
            }
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
                    lesProduits.Add(new Produit((int)dr["produit_id"], (int)dr["recette_id"],
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

        public Int32 Update()
        {
            // On met à jour le prix, le nombre de parts et le booléen d'indisponibilité requis par le sujet
            string req = "UPDATE produit SET prix = @prix, nb_parts = @nb_parts, est_indisponible = @est_indisponible WHERE produit_id = @id;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(req))
            {
                // Forçage strict des types PostgreSQL
                cmd.Parameters.Add("@prix", NpgsqlTypes.NpgsqlDbType.Numeric).Value = this.Prix; // ou .Money selon votre BDD
                cmd.Parameters.Add("@nb_parts", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.Nb_parts;
                cmd.Parameters.Add("@est_indisponible", NpgsqlTypes.NpgsqlDbType.Boolean).Value = this.Est_indisponible;
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.Produit_id;

                // Exécution via votre passerelle DataAccess
                return DataAccess.ExecuteSet(cmd);
            }
        }
    }
}
