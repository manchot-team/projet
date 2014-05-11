using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manchot
{
    class Evenement
    {
        // Field 
        public double absDebut;
        public double absFin;
        public DateTime dateDebut;
        public string heure;

        // Constructor
        public Evenement(double absDebut,DateTime debutDate)
        {
            this.absDebut = absDebut;
            this.dateDebut = debutDate;
            this.heure = debutDate.ToString("mm:ss,fff");
        }

        public Evenement()
        {
            this.absDebut = 0;
            this.dateDebut = new DateTime();
        }

        public void toString()
        {
            Console.WriteLine();
        }

    }
}
