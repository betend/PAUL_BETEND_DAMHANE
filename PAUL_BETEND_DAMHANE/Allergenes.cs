using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_DAMHANE_BETEND
{
    public class Allergenes
    {
        private int allergenes_id;
        private string allergenes_nom;

        public int Allergenes_id
        {
            get
            {
                return this.allergenes_id;
            }

            set
            {
                this.allergenes_id = value;
            }
        }

        public string Allergenes_nom
        {
            get
            {
                return this.allergenes_nom;
            }

            set
            {
                this.allergenes_nom = value;
            }
        }
    }
}
