using System;
using System.Collections.Generic;
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


    }
}
