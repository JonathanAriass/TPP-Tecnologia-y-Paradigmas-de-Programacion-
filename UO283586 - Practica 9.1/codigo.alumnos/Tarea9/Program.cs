using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practica9
{
    class Program
    {
        static void Main(string[] args)
        {
            //var data = Utils.GetBitcoinData();
            /*foreach (var d in data)
                Console.WriteLine(d);*/

            const int maximoHilos = 50;
            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");
            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                Master master = new Master(Utils.GetBitcoinData(), numeroHilos, 7000);
                DateTime antes = DateTime.Now;
                double resultado = master.ComputeModulus();
                DateTime despues = DateTime.Now;
                MostrarLinea(Console.Out, numeroHilos, (despues - antes).Ticks, resultado);

                GC.Collect();
                GC.WaitForFullGCComplete();
            }
            Console.ReadLine();
        }


        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera, string resultadoCabecera)
        {
            stream.WriteLine($"{numHilosCabecera};{ticksCabecera};{resultadoCabecera}");
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }

    }
}
