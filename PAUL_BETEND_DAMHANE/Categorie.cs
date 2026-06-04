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
    public class Categorie: ICrud<Categorie>
    {
        private int categorie_id;
        private string categorie_nom;
        private ObservableCollection<Categorie> lesCategorie;

        public Categorie()
        {
        }

        public Categorie(Int32 categorie_id, String categorie_nom)
        {
            this.Categorie_id = categorie_id;
            this.Categorie_nom = categorie_nom;
        }

        public int Categorie_id
        {
            get
            {
                return this.categorie_id;
            }

            set
            {
                this.categorie_id = value;
            }
        }

        public string Categorie_nom
        {
            get
            {
                return this.categorie_nom;
            }

            set
            {
                this.categorie_nom = value;
            }
        }

        public ObservableCollection<Categorie> LesCategorie
        {
            get
            {
                return this.lesCategorie;
            }

            set
            {
                this.lesCategorie = value;
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

        public List<Categorie> FindAll()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCategories.Add(new Categorie((int)dr["categorie_id"], (string)dr["categorie_nom"]));
            }
            return lesCategories;
        }

        public List<Categorie> FindBySelection(String criteres)
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
