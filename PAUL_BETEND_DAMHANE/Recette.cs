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
    public class Recette : ICrud<Recette>
    {
        private int recette_id;
        private string recette_nom;
        private string recette_description;
        private ObservableCollection<Recette> lesRecettes;
        private ObservableCollection<Allergenes> lesAllergenes;


        public Recette()
        {
        }

        public Recette(Int32 recette_id, String recette_nom, String recette_description)
        {
            this.Recette_id = recette_id;
            this.Recette_nom = recette_nom;
            this.Recette_description = recette_description;
            LesAllergenes = new ObservableCollection<Allergenes>(FindAllergenes());
        }

        public int Recette_id
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

        public string Recette_nom
        {
            get
            {
                return this.recette_nom;
            }

            set
            {
                this.recette_nom = value;
            }
        }

        public string Recette_description
        {
            get
            {
                return this.recette_description;
            }

            set
            {
                this.recette_description = value;
            }
        }

        public ObservableCollection<Recette> LesRecettes
        {
            get
            {
                return this.lesRecettes;
            }

            set
            {
                this.lesRecettes = value;
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


        public List<Allergenes> FindAllergenes()

        {

            List<Allergenes> lesAllergenes = new List<Allergenes>();

            using (NpgsqlCommand cmdSelect = new NpgsqlCommand(

                @"select a.allergene_id, a.allergene_nom

                  from allergene a

                  join recette_allergene ra on ra.allergene_id = a.allergene_id

                  where ra.recette_id = @id"))

            {

                cmdSelect.Parameters.AddWithValue("@id", this.recette_id);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);

                foreach (DataRow dr in dt.Rows)

                {

                    lesAllergenes.Add(new Allergenes((int)dr["allergene_id"],dr["allergene_nom"].ToString()));

                }

            }

            return lesAllergenes;

        }


        public Int32 Create()
        {
            throw new NotImplementedException();
        }

        public Int32 Delete()
        {
            throw new NotImplementedException();
        }

        public List<Recette> FindAll()
        {
            List<Recette> lesRecettes = new List<Recette>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from recette ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRecettes.Add(new Recette((int)dr["recette_id"],
                   (string)dr["recette_nom"], (string)dr["recette_description"]));
            }
            return lesRecettes;
        }

        public List<Recette> FindBySelection(String criteres)
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
