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

namespace PAUL_BETEND_DAMHANE
{
    public class Employe : ICrud<Employe>
    {
        private int employe_id;
        private string employe_login;
        private string employe_role;
        private ObservableCollection<Employe> lesEmployes;

        public Employe()
        {
        }

        public Employe(Int32 employe_id, String employe_login, String employe_role)
        {
            this.Employe_id = employe_id;
            this.Employe_login = employe_login;
            this.Employe_role = employe_role;
        }

        public Int32 Employe_id
        {
            get
            {
                return this.employe_id;
            }

            set
            {
                this.employe_id = value;
            }
        }

        public String Employe_login
        {
            get
            {
                return this.employe_login;
            }

            set
            {
                this.employe_login = value;
            }
        }

        public String Employe_role
        {
            get
            {
                return this.employe_role;
            }

            set
            {
                this.employe_role = value;
            }
        }

        public ObservableCollection<Employe> LesEmployes
        {
            get
            {
                return this.lesEmployes;
            }

            set
            {
                this.lesEmployes = value;
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

        public List<Employe> FindAll()
        {
            List<Employe> lesEmployes = new List<Employe>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from employe;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesEmployes.Add(new Employe((int)dr["employe_id"],
                   (string)dr["employe_login"], (string)dr["employe_role"]));
            }
            return lesEmployes;
        }

        public List<Employe> FindBySelection(String criteres)
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
