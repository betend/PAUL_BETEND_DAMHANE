using Npgsql;
using PAUL_BETEND_DAMHANE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Client : ICrud<Client>, INotifyPropertyChanged
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
                if (String.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Le nom doit être renseigné"); }
                if (value.Length > 50) { throw new ArgumentException("doit avoir moins de 50 caractères"); }
                this.nom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                if (String.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("value"); }
                this.nom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));

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
                if (String.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Le nom doit être renseigné"); }
                if (value.Length > 50) { throw new ArgumentException("doit avoir moins de 50 caractères"); }
                this.prenom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                if (String.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("value"); }
                this.prenom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le numéro de téléphone doit être renseigné.");
                string tel = value.Replace(" ", "");
                if (!Regex.IsMatch(tel, @"^(06|07)\d{8}$"))
                    throw new ArgumentException("Le numéro doit contenir 10 chiffres et commencer par 06 ou 07.");
                telephone = tel;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Telephone)));
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("L'adresse mail doit être renseignée.");
                string email = value.Trim().ToLower();
                try
                {
                    MailAddress adresse = new MailAddress(email);
                    mail = adresse.Address;
                }
                catch
                {
                    throw new ArgumentException("L'adresse mail n'est pas valide.");
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mail)));

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

        public event PropertyChangedEventHandler? PropertyChanged;

        public Int32 Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into client (nom, prenom, telephone, mail ) values ( @nom, @prenom, @telephone, @mail) RETURNING client_id"))
            {

                cmdInsert.Parameters.AddWithValue("nom", this.Nom);
                cmdInsert.Parameters.AddWithValue("prenom", this.Prenom);
                cmdInsert.Parameters.AddWithValue("telephone", this.Telephone);
                cmdInsert.Parameters.AddWithValue("mail", this.Mail);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.Client_id = nb;
            return nb;
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
