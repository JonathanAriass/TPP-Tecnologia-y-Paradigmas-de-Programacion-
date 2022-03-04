using System;
using System.Collections.Generic;
using System.Linq;

namespace delegates
{
    static class Program
    {
        //Declaración de un delegado
        // public delegate double Function(double x);

        // Ejemplo de un método que implementa un delegado
        // TD = tipo del dominio
        // TCD = tipo del codominio
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

        private static double Square(double x)
        {
            return x * x;
        }

        // Si es un método de extension hay que ponerle el this
        static void Show<T>(this IEnumerable<T> collection)
        {
            foreach (T element in collection)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            double[] values1 = new double[] { -3, -2, -1, 0, 1, 2, 3 };
            /**
             * Aqui se llama al metodo Map() para el array de doubles y nos devuelve un
             * array de doubles operando con la funcion pasada como parametro y la muestra llamando
             * al metodo Show()
             */
            values1.Map(x => x * x).Show();    // x => x*x es una función anónima

            /**
             * En este caso se hace lo mismo que en el anterior caso, solo que esta vez el array es de string
             * y la funcion pasada como parametro es pasar el elemento "x" a lowercase y  tambien se llama al 
             * metodo Show()
             */
            string[] values2 = new string[] { "HOLA", "munDO" };
            values2.Map(x => x.ToLower()).Show();

            var values3 = new string[] { "HOLA", "munDO" };
            values3.Map(x => x.Length).Show();
        }
    }
}
