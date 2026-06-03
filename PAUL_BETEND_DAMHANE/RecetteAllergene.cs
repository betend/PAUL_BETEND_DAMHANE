using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_BETEND_DAMHANE
{
    internal class RecetteAllergene
    {
        private int recette_id;
        private int allergene_id;
        private Recette uneRecette;
        private Allergenes unAllergene;

        public Int32 Recette_id
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

        public Int32 Allergene_id
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

        public Recette UneRecette
        {
            get
            {
                return this.uneRecette;
            }

            set
            {
                this.uneRecette = value;
            }
        }

        public Allergenes UnAllergene
        {
            get
            {
                return this.unAllergene;
            }

            set
            {
                this.unAllergene = value;
            }
        }
    }
}
