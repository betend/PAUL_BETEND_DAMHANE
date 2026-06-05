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
    public class CategorieEvenement: ICrud<CategorieEvenement>
    {
        private int categorie_evenement_id;
        private string categorie_evenement_nom;
        private ObservableCollection<CategorieEvenement> lesCategorieEvenement;

        public CategorieEvenement()
        {
        }

        public CategorieEvenement(Int32 categorie_evenement_id, String categorie_evenement_nom)
        {
            this.Categorie_evenement_id = categorie_evenement_id;
            this.Categorie_evenement_nom = categorie_evenement_nom;
        }

        public override string ToString()
        {
            return this.Categorie_evenement_id + " - " + this.Categorie_evenement_nom;
        }

        public int Categorie_evenement_id
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

        public string Categorie_evenement_nom
        {
            get
            {
                return this.categorie_evenement_nom;
            }

            set
            {
                this.categorie_evenement_nom = value;
            }
        }

        public ObservableCollection<CategorieEvenement> LesCategorieEvenement
        {
            get
            {
                return this.lesCategorieEvenement;
            }

            set
            {
                this.lesCategorieEvenement = value;
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

        public List<CategorieEvenement> FindAll()
        {
            List<CategorieEvenement> lesCategorieEvenement = new List<CategorieEvenement>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie_evenement ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCategorieEvenement.Add(new CategorieEvenement((int)dr["categorie_evenement_id"], (string)dr["categorie_evenement_nom"]));
            }
            return lesCategorieEvenement;
        }

        public List<CategorieEvenement> FindBySelection(String criteres)
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
