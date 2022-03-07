using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab06 {

    static class Program {

        static int Addition(int a, int b) {
            return a + b;
        }

        static Func<int, int> CurryedAdd(int a)
        {
            return b => b + a;
        }

        static IEnumerable<TCD> Map<TD, TCD>(this IEnumerable<TD> collection, Func<TD, TCD> f)
        {
            TCD[] result = new TCD[collection.Count()];
            uint i = 0;
            foreach (TD d in collection)
            {
                result[i] = f(d);
                i++;
            }
            return result;
        }

        public static TDomain[] Filter<TDomain>(IEnumerable<TDomain> list, Func<TDomain, bool> function)
        {
            var aux = new TDomain[list.Count()];
            int i = 0;

            foreach (var a in list)
            {
                if (function(a))
                {
                    aux[i] = a;
                    i++;
                }
            }
            Array.Resize(ref aux, i);
            return aux;
        }

        // Esta forma de trabajar se llama method chaning para poder hacer una llamada de metodo mas util,
        // tambien se llama FluentAPIs
        static IEnumerable<T> Show<T>(this IEnumerable<T> collection)
        {
            foreach (T element in collection)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
            return collection;
        }

        static Predicate<int> GreaterThan(int value)
        {
            return b => b > value;
        }

        static void Main() {
            Console.WriteLine(Addition(1, 2));
            Console.WriteLine(CurryedAdd(1)(2));
            var incrementa = CurryedAdd(1);
            Console.WriteLine(incrementa(2));

            int[] values1 = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            values1.Map(x => Addition(x,1)).Show(); // version sin currificacion

            values1.Map(CurryedAdd(1)).Show();

            values1.Map(incrementa).Show();

            var random = new Random();
            var ints = new int[10];
            ints.Map(x => random.Next(-100, 100)).Show();


            // Genera 10 numeros aleatorios, le sumo 1 y lo muestro
            ints.Map(_ => random.Next(-100, 100)).Show().Map(CurryedAdd(1)).Show().Filter(GreaterThan(0)).Show(); // Como no nos interesa el valor de x no lo usamos


        }

    }
}
