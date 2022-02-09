using System;
using ListaEnlazada;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            list.AddNode(2);
            list.AddNode(5);
            list.AddNode(9);
            list.AddNode("Test");
            list.AddNode(null);
            list.AddNode(5);

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
        }
    }
}
