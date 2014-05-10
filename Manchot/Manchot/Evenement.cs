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
        public DateTime heure;

        // Constructor
        public Evenement(double absDebut,DateTime debutDate)
        {
            this.absDebut = absDebut;
            this.dateDebut = debutDate;
        }

        public void toString()
        {
            Console.WriteLine();
        }

    }
}
