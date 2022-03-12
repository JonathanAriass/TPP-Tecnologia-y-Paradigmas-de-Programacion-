using System;
using System.Diagnostics;

namespace TPP.Laboratory.Functional.Lab06 {

    class Program {
        static void Main() {
            int i = 0;
            foreach (int value in Fibonacci.InfiniteFibonacci()) { // poner un punto de interrupcion aqui y ir dandole al F11
                Console.Write(value + " ");
                if (++i == 10)
                    break;
            }
            Console.WriteLine();

            i = 0;
            foreach (int value in Fibonacci.InfiniteFibonacci()) {
                Console.Write(value + " ");
                if (++i == 10)
                    break;
            }
            Console.WriteLine();


            foreach (int value in Fibonacci.LazyFibonacci(10,20))
            {
                Console.Write(value + " ");
                if (++i == 10)
                    break;
            }
            Console.WriteLine();

            var values = Fibonacci.EagerFibonacci(15);


            // Como esta implementado de forma eager se cargar en memoria los 20 valores,
            // aunque solo se vayan a obtener 10 de ellos
            i = 0;
            foreach (int value in Fibonacci.EagerFibonacci(20))
            {
                Console.Write(value + " ");
                if (++i == 10)
                    break;
            }

            // Comparamos los tiempos de la forma eager y la forma lazy, 
            // como sabemos la forma eager consume muchas mas memoria pero se ejecuta mas rapido
            // que la forma lazy.
            var crono = new Stopwatch();
            crono.Start();
            Fibonacci.EagerFibonacci(20);
            crono.Stop();
            long ticksEager = crono.ElapsedTicks;
            Console.WriteLine("\nEager version: {0:N} ticks.", ticksEager);

            crono = new Stopwatch();
            crono.Restart();
            Fibonacci.LazyFibonacci(0,20);
            crono.Stop();
            long ticksLazy = crono.ElapsedTicks;
            Console.WriteLine("Lazy version: {0:N} ticks.", ticksLazy);
        }
    }
}
