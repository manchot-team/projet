using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manchot
{
    class Traitement
    {
        public static double[][] supressionBruit(double[][] measuredData )
        {
            double[][] resData = measuredData;
            //Console.WriteLine("Salut");
            for (int i = 0; i < measuredData.Length; i++)
            {
                for ( int j = 0; j < measuredData[i].Length; j++ ){
                    if (measuredData[i][j] < 0.5)
                    {
                        resData[i][j] = 0;
                    }
                    else
                    {
                        resData[i][j] = measuredData[i][j];
                    }
                }
            }

            return resData;

        }

        /**
         *  Calcule la date (heure et secondes) d'un évenement grâce à la correspondance entre
         *  l'abscisse du début de l'évement et les métadonnées du fichier. 
         */

        public static Evenement dateEvenement(DateTime date,double abscisse)
        {
            DateTime debut = date;
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;
            // Ajout des secondes
            debut = myCal.AddSeconds(debut,Convert.ToInt32(abscisse));

            // Création de l'objet évenement :
            return new Evenement(abscisse,debut);
            
        }


    }
}
