using System;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Try to guess the behavior of this program without running it
    /// </summary>
    class Closures {

        /// <summary>
        /// Version with a single method
        /// </summary>
        static Func<int> Counter1() {
            int counter = 0;
            return () => ++counter;
        }

        static void Counter2(int initValue, out Func<int> increment, out Func<int> decrement, out Action<int> assign)
        {
            int counter = initValue;
            increment = () => counter++;
            decrement = () => counter--;
            assign = (value) => counter = value;
        }

        internal class Counter 
        {
            internal Func<int> increment { get; set; }
            internal Func<int> decrement { get; set; }
            internal Action<int> assign { get; set; }
        }

        static Counter Counter3(int initValue)
        {
            int counter = initValue;
            return new Counter
            {
                increment = () => counter++,
                decrement = () => counter--,
                assign = (value) => counter = value
            };
        }

        static (Func<int> increment, Func<int> decrement, Action<int> assign) Counter4(int initValue) 
        {
            int counter = initValue;
            return (
                () => counter++,
                () => counter--,
                (value) => counter = value
            );
        }

        static void Main() {
            Func<int> counter = Counter1();
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            
            Func<int> anotherCounter = Counter1();
            Console.WriteLine(anotherCounter());
            Console.WriteLine(anotherCounter());

            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine();

            Counter2(10, out Func<int> increment, out Func<int> decrement, out Action<int> assign);
            Console.WriteLine(increment()); // Primero se devuelve y luego se incrementa
            Console.WriteLine(increment()); // Primero se devuelve y luego se incrementa
            assign(20);
            Console.WriteLine(decrement()); // Primero se devuelve y luego se decrementa
            Console.WriteLine(decrement()); // Primero se devuelve y luego se decrementa

            Console.WriteLine();

            var c = Counter3(100);
            Console.WriteLine(c.increment()); // Primero se devuelve y luego se incrementa
            Console.WriteLine(c.increment()); // Primero se devuelve y luego se incrementa
            c.assign(200);
            Console.WriteLine(c.decrement()); // Primero se devuelve y luego se decrementa
            Console.WriteLine(c.decrement()); // Primero se devuelve y luego se decrementa

            Console.WriteLine();

            var tuple = Counter4(1000);
            Console.WriteLine(tuple.increment()); // Primero se devuelve y luego se incrementa
            Console.WriteLine(tuple.increment()); // Primero se devuelve y luego se incrementa
            tuple.assign(2000);
            Console.WriteLine(tuple.decrement()); // Primero se devuelve y luego se decrementa
            Console.WriteLine(tuple.decrement()); // Primero se devuelve y luego se decrementa
        }
    }

}
