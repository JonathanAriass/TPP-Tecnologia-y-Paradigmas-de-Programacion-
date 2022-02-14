using System;

namespace parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 2;
            Swap(ref x, ref y);
            Console.WriteLine("x= {0}\ny= {1}", x, y);


            // para capar la funcion que cumple la referencia se hace uso de "in" o "out"
            AskData(out string firstName, out string surname, out string idNumber);
            Console.WriteLine("\nFirstName= {0}\nSurname= {1}\nIdNumber= {2}", firstName, surname, idNumber);

        }

        /// <summary>
        /// La forma de pasar como referencia por parametro es haciendo uso de la palabra reservada ref
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void AskData(out string firstName, out string surname, out string idNumber)
        {
            Console.Write("First name: ");
            firstName = Console.In.ReadLine();

            Console.Write("Surname: ");
            surname = Console.In.ReadLine();

            Console.Write("idNumber: ");
            idNumber = Console.In.ReadLine();



        }

    }
}
