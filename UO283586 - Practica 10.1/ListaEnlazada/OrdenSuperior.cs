using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ListaEnlazada
{
    public static class OrdenSuperior
    {

        public static T Find<T>(this IEnumerable<T> list, Predicate<T> function)
        {
            foreach (var a in list)
            {
                if (function(a))
                {
                    return a;
                }
            }
            return default(T);
        }

        public static IEnumerable<TDomain> Filter<TDomain>(this IEnumerable<TDomain> list, Predicate<TDomain> function)
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


        // Reduce sin semilla
        public static TCD Reduce<TD, TCD>(this IEnumerable<TD> list, Func<TCD, TD, TCD> func)
        {
            var acc = default(TCD);
            foreach (TD obj in list)
            {
                acc = func(acc, obj);
            }

            return acc;
        }

        // Con semilla
        public static TCD Reduce<TD, TCD>(this IEnumerable<TD> list, Func<TCD, TD, TCD> func, TCD acc = default(TCD))
        {
            foreach (TD obj in list)
            {
                acc = func(acc, obj);
            }

            return acc;
        }

        public static IEnumerable<TCD> Map<TD, TCD>(this IEnumerable<TD> list, Func<TD, TCD> func)
        {
            IList<TCD> res = new List<TCD>();
            foreach (TD obj in list) 
            {
                res.Add(func(obj));
            }
            return res;
        }

        public static void ForEach<T>(this IEnumerable<T> lista, Action<T> accion)
        {
            foreach (T i in lista)
            {
                accion(i);
            }
        }

        public static IEnumerable<T> Invert<T>(this IEnumerable<T> lista)
        {
            T[] aux = new T[lista.Count()];

            var i = 0;
            foreach (T obj in lista) 
            {
                aux[i] = obj;
                i++;
            }

            IList<T> res = new List<T>();

            for (int j = aux.Length - 1; j >= 0; j--)
            {
                res.Add(aux[j]);
            }

            return res;
        }

    }
}
