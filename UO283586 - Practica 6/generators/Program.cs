using System;

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
        }
    }
}
