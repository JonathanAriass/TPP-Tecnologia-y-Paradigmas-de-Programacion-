using System;
using System.Diagnostics;
using logica;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = Procesador.LeerFicheroText(@"..\..\..\..\clarin.txt");
            string[] words = Procesador.DividirPalabras(text);

            Stopwatch crono = new Stopwatch();
            crono.Start();
            Procesador.PalabrasRepetidasParallel(words);
            crono.Stop();

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);


            crono.Reset();


            crono.Start();
            Procesador.PalabrasRepetidasSecuencial(words);
            crono.Stop();

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);


            crono.Reset();


            crono.Start();
            var dic = Procesador.PalabrasRepetidasAsParallel(words);
            /*foreach (var el in dic)
            {
                Console.WriteLine($"Palabra: {el.Key}\t\tRepeticiones: {el.Value}");
            }*/
            crono.Stop();
            //Console.WriteLine($"Numero de lineas: {dic.Count}");
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);
        }
    }
}
