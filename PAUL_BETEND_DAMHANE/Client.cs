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
    public class Client : ICrud<Client>
    {
        private int client_id;
        private string nom;
        private string prenom;
        private string telephone;
        private string mail;
        private ObservableCollection<Client> lesClients;

        public Client()
        {
        }

        public Client(Int32 client_id, String nom, String prenom, string telephone, String mail)
        {
            this.Client_id = client_id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
            this.Mail = mail;
        }

        public int Client_id
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

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }

        public string Telephone
        {
            get
            {
                return this.telephone;
            }

            set
            {
                this.telephone = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }

            set
            {
                this.mail = value;
            }
        }

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
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

        public List<Client> FindAll()
        {
            List<Client> lesClients = new List<Client>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from client;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesClients.Add(new Client((int)dr["client_id"],
                   (string)dr["nom"], (string)dr["prenom"], (string)dr["telephone"], (string)dr["mail"]));
            }
            return lesClients;
        }

        public List<Client> FindBySelection(String criteres)
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
