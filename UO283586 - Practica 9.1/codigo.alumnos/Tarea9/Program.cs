using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Stopwatch crono = new Stopwatch();
            

            const int maximoHilos = 50;
            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");
            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                Master master = new Master(Utils.GetBitcoinData(), numeroHilos, 7000);
                //DateTime antes = DateTime.Now;
                crono.Start();
                double resultado = master.ComputeModulus();
                crono.Stop();
                //DateTime despues = DateTime.Now;
                //MostrarLinea(Console.Out, numeroHilos, (despues - antes).Ticks, resultado);
                Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);

                GC.Collect();
                GC.WaitForFullGCComplete();
            }
            Console.ReadLine();

            var data = Utils.GetBitcoinData();

            double min = 7000;

            crono.Reset();

            crono.Start();
            Parallel.ForEach(data, n =>
            {
                ContarNumeros(min, data);
            });
            crono.Stop();
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);

            var result = data.AsParallel().Aggregate(new int(), (res, n) =>
            {
                if (n.Value > min)
                {
                    res++;
                }
                //Console.WriteLine($"Valor: {n.Value}");
                return res;
            });

            Console.Write($"Resultado: {result}");

            crono.Reset();
            //DateTime antes2 = DateTime.Now;
            crono.Start();
            var result2 = data.AsParallel().Count(n => n.Value > min);
            crono.Stop();
            //DateTime despues2 = DateTime.Now;
            //MostrarLinea(Console.Out, (despues2 - antes2).Ticks, result2);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);
            Console.Write($"Resultado: {result2}\n\n");


        }

        private static void ContarNumeros(double min, BitcoinValueData[] data) {
            int repeticiones = data.Count(n => n.Value> min);
            //Console.WriteLine($"Numero: {min}\t\tRepeticiones: {repeticiones}");
        }

        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera, string resultadoCabecera)
        {
            stream.WriteLine($"{numHilosCabecera};{ticksCabecera};{resultadoCabecera}");
        }

        static void MostrarLinea(TextWriter stream, long ticksCabecera, int resultadoCabecera)
        {
            stream.WriteLine($"{ticksCabecera};{resultadoCabecera}");
        }
        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }

    }
}
