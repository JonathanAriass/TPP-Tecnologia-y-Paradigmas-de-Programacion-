using System;

namespace TPP.Laboratory.Concurrency.Lab10
{

    public class Color {

        private ConsoleColor color;

        public Color(ConsoleColor color) {
            this.color = color;
        }

        // Se esta compartiendo el color de la letra y la salida de la consola
        // Hay que usar un lock para que los valores no se cambien entre hilos
        // En el Lock se tiene que pasar por referencia el objeto compartido
        virtual public void Show() {
            //lock (Console.Out) {
                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = this.color;
                Console.Write("{0}\t", this.color);
                Console.ForegroundColor = previousColor;
            //}
        }

    }
}
