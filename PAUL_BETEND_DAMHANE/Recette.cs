using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Recette
    {
        private int recette_id;
        private string recette_nom;
        private string recette_description;

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
    }
}
