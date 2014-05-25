using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manchot
{
    class Evenement
    {
        /// <summary>
        /// Abscisse du début de l'évenement
        /// </summary>
        public double absDebut;
        /// <summary>
        /// Abscisse de fin de l'évenement
        /// </summary>
        public double absFin;
        /// <summary>
        /// Date de début de l'évenement
        /// Calculé grâce à l'abscisse et les métadata du fichier
        /// </summary>
        public DateTime dateDebut;
        /// <summary>
        /// Heure à laquelle l'évenement survient
        /// </summary>
        public string heure;
        /// <summary>
        /// Résultat de l'analyse pour l'évenement
        /// </summary>
        public string analyse;

        /// <summary>
        /// Surchage du constructeur de la classe evenement
        /// </summary>
        /// <param name="absDebut">L'abscisse du début de l'évenement </param>
        /// <param name="debutDate">La date du début de l'évenement</param>
        public Evenement(double absDebut,DateTime debutDate)
        {
            this.absDebut = absDebut;
            this.dateDebut = debutDate;
            this.heure = debutDate.ToString("mm:ss,fff");
        }

        /// <summary>
        /// Constructeur de la classe evenement
        /// </summary>
        public Evenement()
        {
            this.absDebut = 0;
            this.dateDebut = new DateTime();
        }

        /// <summary>
        /// L'algorihtme d'analyse de détection des cas simples. Permet de completer le champ anlayse de l'evenement
        /// </summary>
        /// <param name="data"> Tableau de Double contenant les données</param>
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
