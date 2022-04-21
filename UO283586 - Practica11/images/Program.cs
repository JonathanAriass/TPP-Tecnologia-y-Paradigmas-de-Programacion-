using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TPP.Laboratory.Concurrency.Lab11 {

    class Program {

        static void Main() {
            Stopwatch chrono = new Stopwatch();
            string[] files = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);
            chrono.Start();
            foreach (string file in files) {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    //Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }
            chrono.Stop();
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", chrono.ElapsedMilliseconds);

            chrono.Reset(); // Necesario porque sino se sigue con el mismo contador
            Console.WriteLine("---------------------------------------------------------");

            var threads = new HashSet<int>();

            chrono.Start();
            Parallel.ForEach(files, file => {
                // OJO!!!!!! QUE ES UN RECURSO COMPARTIDO Y ES UNA CONDICION DE CARRERA
                lock (threads)
                {
                   threads.Add(Thread.CurrentThread.ManagedThreadId);
                }
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    // Console.WriteLine("Processing the file \"{0}\".", fileName); Condicion de carrera, hay que poner un lock si queremos mostrar el mensaje
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            });
            chrono.Stop();
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", chrono.ElapsedMilliseconds);
            Console.WriteLine($"using {threads.Count} threads");
        }
    }

}
