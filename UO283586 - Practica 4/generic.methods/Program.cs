using System;

namespace generic.methods
{
    class Program
    {
        /// <summary>
        /// En este caso la generacidad nos permite que solo los dos parametros sean validos
        /// si son del mismo tipo concetro, esto no pasa con implementacines polimorficas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /*static T MaxValue<T>(T a , T b) where T:
        {
            return a > b ? a : b;
        }*/

        static IComparable MaxValue1(IComparable a, IComparable b)
        { 
            return a.CompareTo(b) >= 0 ? a : b;
        }

        static IComparable<T> MaxValue2<T>(IComparable<T> a, IComparable<T> b)
        {
            return a.CompareTo((T)b) >= 0 ? a : b;
        }

        static T MaxValue3<T>(IComparable<T> a, IComparable<T> b)
        {
            return (T) (a.CompareTo((T)b) >= 0 ? a : b);
        }

        /// <summary>
        /// En este caso, con la restriccion, nos aseguramos de que T es de tipo IComparable.
        /// Es igual que al anterior version, solo que nos ahorramos los casteos al tener dicha restriccion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static T MaxValue4<T>(T a, T b) where T:IComparable<T>
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }

        static void Main(string[] args)
        {
            int x = 1; 
            int y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");

            int m1 = (int) MaxValue1((IComparable)x, (IComparable)y);
            Console.WriteLine($"m1 = {m1}");

            int m2 = (int)MaxValue2(x, y); //Este casteo es mucho menos peligroso que el anterior
            Console.WriteLine($"m2 = {m2}");

            int m3 = MaxValue3(x, y);
            Console.WriteLine($"m3 = {m3}");

            int m4 = MaxValue4(x, y);
            Console.WriteLine($"m4 = {m4}");
        }
    }

    /// COSAS A HACER
    /// Pillar lista polimorfica y pasar a generica
    ///     - NO hace falta hacer generecidad acotada
    /// Implementar la interfaz IEnumerable en la lista
    /// Hacer ejercicio de la semana que viene
}
