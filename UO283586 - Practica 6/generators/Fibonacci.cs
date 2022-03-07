using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    static class Fibonacci {

        static internal IEnumerable<int> InfiniteFibonacci() {
            int first = 1, second = 1;
            while (true) {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }

    }

}
