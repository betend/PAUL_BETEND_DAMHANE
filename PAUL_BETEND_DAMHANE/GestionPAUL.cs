using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_BETEND_DAMHANE
{
    public class GestionPAUL
    {
        public ObservableCollection<Produit> lesProduits;
        private string nom;

        public GestionPAUL()
        {
            LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());

        }
        public GestionPAUL(string nom)
        {

            this.Nom = nom;
            LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());

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

        public String Nom
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
    }
}
