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

        /// <summary>
        /// Fonction de filtrage : permet de lisser la courbe en utilisant un algorithme
        /// de filtre moyenneur. Chaque valeur et la moyenne de la valeur la précédente et la valeur
        /// la succédant
        /// </summary>
        /// <param name="measureData">Contient les tableaux de données</param>
        /// <returns>Un tableau des tableaux de données, après l'application du filtre moyenneur</returns>
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

        /// <summary>
        /// Calcul le médian d'un tableau de double à une dimension
        /// </summary>
        /// <param name="arr">Array : tableau de double</param>
        /// <returns>Le médian du tableau</returns>
        public static double median(double[] arr)
        {
            double[] s = arr;
            Array.Sort(s);
            int mil = (s.Length - 1) / 2;
            return s[mil];
        }

        /// <summary>
        /// Applique un filtre médian de taille wl, sur un tableau arr de double, permettant ainsi 
        /// de supprimer les valeurs abbérantes
        /// </summary>
        /// <param name="arr">Array : Le tableau à traiter</param>
        /// <param name="wl">WindowLenght : la taille de la fenetre glissante du filtre médian</param>
        /// <returns> Retourne le tableau avec les valeurs abbérantes supprimer par le filtre médian</returns>
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

        /// <summary>
        /// Calcul le pourcentage de bruit dans les fichiers TDMS données
        /// </summary>
        /// <param name="measuredData">Contient les données des fichiers TDMS</param>
        /// <returns>Pourcentage de bruit des fichiers TDMS</returns>
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
