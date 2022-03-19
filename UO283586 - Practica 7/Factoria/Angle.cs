
using System;

namespace TPP.Laboratory.Functional.Lab05 {

    public class Angle {

        public double Radians { get; private set; }

        public float Degrees {
            get { return (float)(this.Radians / Math.PI * 180); }
        }

        public Angle(double radians) {
            this.Radians = radians;
        }

        public Angle(float degrees) {
            this.Radians = degrees / 180.0 * Math.PI;
        }

        public double Sine() {
            return Math.Sin(this.Radians);
        }

        public double Cosine() {
            return Math.Cos(this.Radians);
        }

        public double Tangent() {
            return Sine() / Cosine();
        }


        public int Quadrant {
            get {
                if (this.Radians <= Math.PI / 2)
                    return 1;
                if (this.Radians <= Math.PI)
                    return 2;
                if (this.Radians <= 3 * Math.PI / 2)
                    return 3;
                return 4;
            }
        }

    }

}