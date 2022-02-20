
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Angle {


        public double Radians { set; get; }

        public double Degrees {
            get {
                return this.Radians / Math.PI * 180;
            }
            set {
                this.Radians = value / 180 * Math.PI;
            }
        }

        public Angle(double radians) {
            this.Radians = radians;
        }

        static public Angle CreateAngleDegrees(double degrees) {
            Angle angle = new Angle(0);
            angle.Degrees = degrees;
            return angle;
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


        public override bool Equals(object obj)
        {
            Angle angle = obj as Angle;
            if (angle == null)
                return false;
            return this.Radians.Equals(angle.Radians);
        }

        public override int GetHashCode()
        {
            return this.Radians.GetHashCode();
        }


        public override string ToString()
        {
            return $"<Angle {Radians}>";
        }
    }

}