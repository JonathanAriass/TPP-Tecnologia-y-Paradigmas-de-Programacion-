using System.Collections.Generic;
using System;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab07 {

    class Program {


        static void Main() {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            integers.Map(x => { Console.WriteLine(x); return x; }).Last(); // Con las llaves se puede hacer como el codigo de una funcion normal, el problema
            // es que a una funcion lambda le tenemos que pasar una expresion y no una sentencia como es el Console.Writeline
            // A un generador como es el Map() le tenemos que pedir el valor, forzando que se ejecute el generador. Esto lo podemos hacer con una 
            // funcion de Linq que es el Last, y por narices tiene que iterar a traves del array
            integers.ForEach(Console.WriteLine);
        }
    }
}
