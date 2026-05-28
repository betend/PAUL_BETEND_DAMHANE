using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Categorie
    {
        private int categorie_id;
        private string categorie_nom;

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
    }
}
