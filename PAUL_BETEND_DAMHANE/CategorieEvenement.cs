using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class CategorieEvenement
    {
        private int categorie_evenement_id;
        private string categorie_evenement_nom;

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
    }
}
