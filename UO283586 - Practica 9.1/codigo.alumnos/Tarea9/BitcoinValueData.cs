using System;

namespace Practica9
{
    public class BitcoinValueData
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return Timestamp + ": " + Value;
        }
    }
}
