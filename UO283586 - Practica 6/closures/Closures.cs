using System;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Try to guess the behavior of this program without running it
    /// </summary>
    class Closures {

        /// <summary>
        /// Version with a single method
        /// </summary>
        static Func<int> Counter() {
            int counter = 0;
            return () => ++counter;
        }

        static void Main() {
            Func<int> counter = Counter();
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            
            Func<int> anotherCounter = Counter();
            Console.WriteLine(anotherCounter());
            Console.WriteLine(anotherCounter());

            Console.WriteLine(counter());
            Console.WriteLine(counter());
        }
    }

}
