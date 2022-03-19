using System.Linq;
using System.Collections.Generic;
using System;

namespace TPP.Laboratory.Functional.Lab07 {

    static public class Functions {

        public static IEnumerable<TResult> Map<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function) {
            TResult[] result = new TResult[collection.Count()]; // Si llamamos al infinite Fibonacci aqui no sabe que tamaño darle
            uint i = 0;
            foreach (TElement d in collection) // Si el iterador es efimero aqui ya no se podria recorrer la lista, puesto que en el count ya se usa
            {
                yield return function(d); // Esto de vuelve un generator
                i++;
            }
        }

        // Este serie Eager
        public static void ForEach<T>(this IEnumerable<T> lista, Action<T> accion)
        {
            foreach (T i in lista)
            {
                accion(i);
            }
        }

    }
}
