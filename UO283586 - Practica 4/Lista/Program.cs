using System;
using ListaEnlazada;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    class Program
    {

        static public void ShowWithForEach<T>(IEnumerable<T> enumerable, TextWriter output)
        {
            output.Write("[ ");
            foreach (T node in enumerable)
                output.Write("{0} ", node);
            output.WriteLine("]");
        }

        static public void ShowWithEnumerator<T>(IEnumerable<T> enumerable, TextWriter output)
        {
            IEnumerator<T> iterador = enumerable.GetEnumerator();
            output.Write("[ ");
            while (iterador.MoveNext()) 
                output.Write("{0} ", iterador.Current);
            output.WriteLine("]");
        }

        static void Main(string[] args)
        {
            Lista<object> list = new Lista<object>();

            list.AddNode(2);
            list.AddNode(5);
            list.AddNode(9);
            list.AddNode("Test");
            list.AddNode(true);
            list.AddNode(5);

            ShowWithForEach(list, Console.Out);
            ShowWithEnumerator(list, Console.Out);

            //Console.WriteLine(list.ToString());
            /**
            list.Print();

            list.Remove("Test");

            list.Print();
            Console.WriteLine("Numero de elementos de la lista: " + list.NumberOfElements + "\n");

            list.Remove(9);
            list.Print();
            list.Remove(300);

            list.AddNode(6, 0);
            list.Print();

            list.AddNode(11, 2);
            list.Print();
            Console.WriteLine("Numero de elementos de la lista: " + list.NumberOfElements + "\n");

            Console.WriteLine("El nodo en la posicion (1) es: " + list.GetElement(1) + "\n");

            list.GetElement(3);

            Console.WriteLine("\n");

            list.Remove(1);

            Console.WriteLine("\n");

            Console.WriteLine("Numero de elementos de la lista: " + list.NumberOfElements);
            */
        }
    }
}
