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
        /// <summary>
        /// Fonction permettant de supprimer le bruit proche de 0 : Lorsqu'une
        /// valeur est inferieur à 0.5, la met à 0
        /// </summary>
        /// <param name="measuredData"></param>
        /// <returns></returns>
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

        public static double[][] filtreMoyenne(double[][] measureData)
        {
            double[][] resData = measureData;

            for (int i = 0; i < measureData.Length; i++)
            {
                for (int j = 1; j < measureData[i].Length - 1; j++)
                {
                    resData[i][j] = (resData[i][j - 1] + resData[i][j + 1]) / 2;
                }
            }
            return resData;
        }

        public static double median(double[] arr)
        {
            double[] s = arr;
            Array.Sort(s);
            int mil = (s.Length - 1) / 2;
            return s[mil];
        }

        public static double[] filtreMedian(double[] arr, double wl) {
            if (arr.Length < wl)
                return arr;
            List<double> f = new List<double>();
            List<double> w = new List<double>();
            int i;

            w.Add(arr[0]);
            for (i=0; i < arr.Length ; i++){
                if (arr.Length -1 >= i + Math.Floor(wl/2))
                    w.Add(arr[i + (int) Math.Floor(wl/2) ]);
                double[] wArray = w.ToArray();
                f.Add(median(wArray));
                if (i >= Math.Floor(wl / 2))
                    w.RemoveAt(0);
                    
            }

            return f.ToArray();

        }

        public static double pourcentageBruit(double[][] measuredData)
        {
            int bruit = 0;
            int taille = 0;
            for (int i = 0; i < measuredData.Length; i++)
            {
                for (int j = 0; j < measuredData[i].Length; j++)
                {
                    if (measuredData[i][j] < 0.5)
                    {
                        bruit++;
                    }
                }
            }
            for (int i = 0; i < measuredData.Length; i++)
            {
                taille = taille + measuredData[i].Length;
            }
            Console.WriteLine(taille);
            return (bruit*100/ taille);
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
            debut = myCal.AddMilliseconds(debut,Convert.ToInt32(abscisse));

            // Création de l'objet évenement :
            return new Evenement(abscisse,debut);
            
        }


    }
}
