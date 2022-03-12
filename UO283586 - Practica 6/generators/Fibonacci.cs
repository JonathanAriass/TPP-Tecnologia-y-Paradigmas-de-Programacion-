using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    static class Fibonacci {

        static internal IEnumerable<int> InfiniteFibonacci() {
            int first = 1, second = 1;
            while (true) {
                yield return first; // la ejecucion se queda parada aqui hasta que se llame al next()
                int addition = first + second;
                first = second;
                second = addition;
            }
        }// Cuando se llama al break en el foreach de Program.cs se llama al Dispose() del enumerator y se para la ejecucion


        // skip ignora los n-valores que pasas como parametros y take toma los n-valores pasados como parametros
        static public IEnumerable<int> LazyFibonacci(int from, int to) 
        {
            return InfiniteFibonacci().Skip(from - 1).Take(to - from - 1);
        }

        // Hay que comparar el lazyfibonacci con el eagerfibonacci con el chrono
        // hay que implementar el LazyFibonacci de forma eager
        static public IEnumerable<int> EagerFibonacci(int n) 
        {
            var res = new int[n];
            res[0] = res[1] = 1;
            for (int i = 2; i < n; i++) 
            {
                res[i] = res[i - 2] + res[i - 1];
            }
            return res;
        }
    }

}
