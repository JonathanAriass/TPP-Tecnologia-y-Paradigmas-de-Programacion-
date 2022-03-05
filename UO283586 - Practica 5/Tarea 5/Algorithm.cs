using System;
using System.Collections.Generic;
using System.Text;

namespace TPP.Laboratory.Functional.Lab05
{
    public class Algorithm
    {

        public static bool BuscarLetra(Person persona) 
        {
            string ultimaLetra = persona.IDNumber.Substring(persona.IDNumber.Length - 1, 1);

            if (ultimaLetra.Equals("R"))
            {
                return true;
            }
            return false;
        }

        public static bool BuscarAngulo(Angle angle)
        {
            if (angle.Quadrant.Equals(1) && angle.Degrees.Equals(90))
            {
                return true;
            }
            return false;
        }

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


        // METODO FILTER

        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> list, Func<T, bool> function)
        {
            IList<T> aux = new List<T>();

            foreach (var a in list)
            {
                if (function(a))
                {
                    aux.Add(a);
                }
            }
            return aux;
        }

        // Forma con el Predicate
        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> list, Predicate<T> function)
        {
            IList<T> aux = new List<T>();

            foreach (var a in list)
            {
                if (function(a))
                {
                    aux.Add(a);
                }
            }
            return aux;
        }

    }
}
