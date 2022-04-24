using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace logica
{
    public class Procesador
    {

        private static void ContarPalabra(string palabra, string[] palabras) {
            int repeticiones = palabras.Count(p => p.Equals(palabra));
            //Console.WriteLine($"Palabra: {palabra}\t\tRepeticiones: {repeticiones}");
        }

        public static void PalabrasRepetidasSecuencial(string[] palabras) {
            var textoFiltrado = palabras.Distinct();

            foreach (var i in textoFiltrado) {
                ContarPalabra(i, palabras);
            }
        }

        

        public static void PalabrasRepetidasParallel(string[] palabras) {
            //var threads = new HashSet<int>();
            var textoFiltrado = palabras.Distinct();
            //Console.WriteLine($"Numero de lineas: {textoFiltrado.Count()}");
            Parallel.ForEach(textoFiltrado, p => {
                /*lock (threads) {
                    threads.Add(Thread.CurrentThread.ManagedThreadId);
                }*/
                ContarPalabra(p, palabras);
                });
            //Console.WriteLine($"using {threads.Count} threads");
        }

        public static Dictionary<string, int> PalabrasRepetidasAsParallel(string[] palabras) {
            return palabras.AsParallel().Aggregate(new Dictionary<string, int>(), (dict1, word) =>
            {
                // Se necesita el lock puesto que el diccionario puede estar seleccionando la misma palabra en varios
                // hilos y si es la primera vez que aparece el resultado seria 1 y no 2
                lock (dict1) { 
                    if (!dict1.ContainsKey(word))
                        dict1[word] = 1;
                    else
                        dict1[word]++;
                    return dict1;   
                }
            });
        }

        public static string[] DividirPalabras(String texto) {
            return texto.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        public static String LeerFicheroText(string fichero) {
            using (StreamReader stream = File.OpenText(fichero)) {
                StringBuilder text = new StringBuilder();
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    text.AppendLine(line);
                }
                return text.ToString();
            }
        }

    }
}
