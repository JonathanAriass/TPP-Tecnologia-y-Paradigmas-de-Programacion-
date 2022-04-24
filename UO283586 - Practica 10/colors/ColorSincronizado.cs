using System;
using System.Collections.Generic;
using System.Text;
using TPP.Laboratory.Concurrency.Lab10;

namespace colors
{
    class ColorSincronizado : Color
    {
        public ColorSincronizado(ConsoleColor color) : base(color) { 
        }

        public override void Show()
        {
            lock (Console.Out) { 
                base.Show();
            }
        }
    }
}
