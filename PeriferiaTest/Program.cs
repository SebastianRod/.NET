using System;
using System.Collections.Generic;

namespace PeriferiaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BingoNumbers();
            PrimeNumbers();
            CadenaSort();
        }

        private static void BingoNumbers()
        {
            Console.WriteLine("----------Inicio del metodo Bingo!----------");
            int limit = 100;
            for (int i = 1; i <= limit; i++)
            {
                string result;
                bool bin = i % 3 == 0;
                bool go = i % 5 == 0;

                if (bin || go)
                {
                    result = bin && go ? i + " Bingo!" : bin && !go ? i + " Bin" : i + " Go";
                }
                else
                {
                    result = "En " + i + " no se cumple ninguna condicion";
                }

                Console.WriteLine(result);
            }

            Console.WriteLine("----------Final del metodo Bingo!----------");
        }

        private static void PrimeNumbers()
        {
            Console.WriteLine("----------Inicio del metodo Primos!----------");

            List<int> result = new List<int>();
            int numDiv = 2;

            while(result.Count < 50)
            {
                var esPrimo = result.Find(primo => numDiv % primo == 0);
                if (esPrimo == 0)
                {
                    result.Add(numDiv);
                }
                numDiv++;
            }

            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("----------Final del metodo Primos!----------");
        }

        private static void CadenaSort()
        {
            Console.WriteLine("----------Inicio del metodo de cadenas!----------");

            Console.WriteLine("Ingrese cadena de string: ");
            var cadena = Console.ReadLine();
            string cadenaResult =  string.Empty;

            if (cadena != "")
            {
                var result = cadena.Split(" ");
                var cont = result.Length;
                for(int i = 0; i < result.Length; i++)
                {
                    cadenaResult += result[cont - 1] + " ";
                    cont--;
                }
                Console.WriteLine(cadenaResult);
            }

            Console.WriteLine("----------Final del metodo de cadenas!----------");
        }
    }
}
