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
        public string analyse;

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

        public void analyser(Double[] data)
        {
            int i = (int)this.absDebut;
            bool sortie = false;
            bool croissant = true;
            bool stagnation = false;
            bool decroissant = false;
            while(i < this.absFin && !sortie)
            {
               // L'algo se présente ainsi : D'abord on essaye de déterminer dans quelle phase on est, ensuite on fonction de cette phase on fera des test différents
                
                if( (data[i+1000] < data[i] + 3))           // Le 3 ici représente pour moi le poids mini qu'un manchot va peser en montant sur la balance
                {
                    croissant = false;
                    double borneSup = data[i-10] + 0.10;        // On prend une valeur 100 milisecondes plus tot et regardons si la valeur est proche à 0,10 près
                    double borneInf = borneSup - 0.20;          // On pourrai conclure qu'on ai dans la "stagnation" donc l'étape intermediaire
                    if (borneInf < data[i] && data[i] < borneSup)
                    {
                        stagnation = true;
                    }
                    else                                     // Si les 2 autres cas sont écartés, il ne reste que celui ci
                    {
                        decroissant = true;
                    }
                }
                    
                if (data[i] < data[i - 30] && croissant)
                {
                    sortie = true;
                }
                else if (data[i] > data[i + 10])
                {
                }
            }
        
        }

        public void toString()
        {
            Console.WriteLine();
        }

    }
}
