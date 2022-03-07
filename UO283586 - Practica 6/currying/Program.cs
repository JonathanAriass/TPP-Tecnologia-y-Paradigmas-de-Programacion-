using System;

namespace TPP.Laboratory.Functional.Lab06 {

    class Program {

        static int Addition(int a, int b) {
            return a + b;
        }

        static Func<int, int> CurryedAdd(int a)
        {
            return b => b + a;
        }

        static void Main() {
            Console.WriteLine(Addition(1, 2));
        }

    }
}
