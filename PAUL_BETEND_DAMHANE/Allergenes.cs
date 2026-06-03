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
    public class Allergenes: ICrud<Allergenes>
    {
        private int allergene_id;
        private string allergene_nom;
        private ObservableCollection<Allergenes> lesAllergenes;

        public Allergenes()
        {
        }

        public Allergenes(Int32 allergene_id, String allergene_nom)
        {
            this.Allergene_id = allergene_id;
            this.Allergene_nom = allergene_nom;
        }

        public int Allergene_id
        {
            get
            {
                return this.allergene_id;
            }

            set
            {
                this.allergene_id = value;
            }
        }

        public string Allergene_nom
        {
            get
            {
                return this.allergene_nom;
            }

            set
            {
                this.allergene_nom = value;
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

        public Int32 Create()
        {
            throw new NotImplementedException();
        }

        public Int32 Delete()
        {
            throw new NotImplementedException();
        }

        public List<Allergenes> FindAll()
        {
            List<Allergenes> lesProduits = new List<Allergenes>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from allergene ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesProduits.Add(new Allergenes((int)dr["allergene_id"], (string)dr["allergene_nom"]));
            }
            return lesProduits;
        }

        public List<Allergenes> FindBySelection(String criteres)
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
