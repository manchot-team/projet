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
            int pointValide = 0;
            bool croissant = true;
            bool stagnation = false;
            bool decroissant = false;
           
            while(i < this.absFin)
            {
             

                if (data[i] < data[i + 10])           // En rentrant dans ce if ca signifie que c'est la phase de croissance
                {
                    croissant = true;
                    pointValide++;
                }
                else if(data[i] == data[i + 10] && croissant || data[i] == data[i + 10] && stagnation) // Ici c'est ou la stagnation ou la transition entre croissance et stagnation
                {    
                    croissant = false;
                    stagnation = true;
                    pointValide++;
                }
                else if(data[i] > data[i + 10] && stagnation || data[i] > data[i + 10] && decroissant) // Ici c'est décroissance ou transition stagnation à décroissance
                {
                    stagnation = false;
                    decroissant = true;
                    pointValide++;
                }
                
      
                i++;
            }

            // La variable pointValide est incrémenté quand un point est dans une phase, pour que ce soit un cas simple tout les points doivent 
            // être dans une phase, donc cette variable doit être égale à l'ensemble des points avec une petite marge d'erreur
            if (pointValide > this.absFin - this.absDebut - 20 && pointValide < this.absFin - this.absDebut + 20)
            {
                this.analyse = "Un manchot est passé sur le plateau";
            }
            else
            {
                this.analyse = "Notre algorithme n'a pas été capable de déterminer l'évenement en dehors de son éxistence";
            }
        
        }

        public void toString()
        {
            Console.WriteLine();
        }

    }
}
