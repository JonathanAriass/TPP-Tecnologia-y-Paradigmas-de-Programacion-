using colors;
using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{

    public class Program {

        public static readonly ConsoleColor[] colors = { 
                    ConsoleColor.DarkBlue,  ConsoleColor.DarkGreen,  ConsoleColor.DarkCyan, 
	                ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,  ConsoleColor.DarkYellow,  
	                ConsoleColor.DarkGray,  ConsoleColor.Blue,  ConsoleColor.Green,  
                    ConsoleColor.Cyan,  ConsoleColor.Red, ConsoleColor.Gray, 
	                ConsoleColor.Magenta,  ConsoleColor.Yellow, ConsoleColor.White,
                    ConsoleColor.DarkBlue,  ConsoleColor.DarkGreen,  ConsoleColor.DarkCyan, 
	                ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,  ConsoleColor.DarkYellow,  
	                ConsoleColor.DarkGray,  ConsoleColor.Blue,  ConsoleColor.Green,  
                    ConsoleColor.Cyan,  ConsoleColor.Red, ConsoleColor.Gray, 
	                ConsoleColor.Magenta,  ConsoleColor.Yellow, ConsoleColor.White,
                    };

        static void Main() {
            Console.WriteLine($"Version sin sincronizar\n");
            Thread[] threads = new Thread[colors.Length];
            for (int i = 0; i < colors.Length; i++) {
                Color color = new Color(colors[i]);
                threads[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threads)
                thread.Start();

            foreach (Thread thread in threads)
                thread.Join();

            Console.WriteLine($"\n\n\nVersion sincronizada\n");

            Thread[] threadsSincronizado = new Thread[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                ColorSincronizado color = new ColorSincronizado(colors[i]);
                threadsSincronizado[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threadsSincronizado)
                thread.Start();
            foreach (Thread thread in threads)
                thread.Join();
        }

    }
}
