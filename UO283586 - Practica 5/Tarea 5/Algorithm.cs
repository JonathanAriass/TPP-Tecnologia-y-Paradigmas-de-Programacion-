using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab05
{
    public static class Algorithm
    {

        

        public static bool BuscarAngulo(Angle angle)
        {
            if (angle.Quadrant.Equals(1) && angle.Degrees.Equals(90))
            {
                return true;
            }
            return false;
        }

        /**
        public static T Buscar<T>(IEnumerable<T> list, Func<T,bool> function)
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
       */

        /*
        public static TDomain Buscar<TDomain>(IEnumerable<TDomain> list, Func<TDomain, bool> function)
        {
            foreach (var a in list)
            {
                if (function(a))
                {
                    return a;
                }
            }
            return default(TDomain);
        }*/
        


        // Mismo metodo pero con un Predicate en vez de con una Func

        public static T BuscarPred<T>(IEnumerable<T> list, Predicate<T> function)
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

        public static bool BuscarLetra(Person persona)
        {
            string ultimaLetra = persona.IDNumber.Substring(persona.IDNumber.Length - 1, 1);

            if (ultimaLetra.Equals("R"))
            {
                return true;
            }
            return false;
        }


        // METODO FILTER
        /*
        public static TDomain[] Filtrar<TDomain>(IEnumerable<TDomain> list, Func<TDomain, bool> function)
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
        */

        // Forma con el Predicate
        
        public static IEnumerable<TDomain> FiltrarPred<TDomain>(IEnumerable<TDomain> list, Predicate<TDomain> function)
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
        

        
        public static TCD Reducir<TD, TCD>(this IEnumerable<TD> list, Func<TCD,TD,TCD> func, TCD acc = default(TCD) )
        {
            foreach (TD obj in list)
            {
                acc = func(acc, obj);
            }

            return acc;
        }
        

    }
}
