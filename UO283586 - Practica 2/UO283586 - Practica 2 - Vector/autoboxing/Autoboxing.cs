using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    class Autoboxing {

		private static int AutoboxingDemo(Int32 obj) {
			return obj;
		}

		private static void Demo() {
			int i=3;
			Int32 oi=i;
			Object o=i;
            AutoboxingDemo(3);
			Console.WriteLine(o);

            // en este caso se trata de autounboxing
            i=oi;
			Console.WriteLine(i);
            i = (int)o;
            int unbox = AutoboxingDemo(3); 
            Console.WriteLine(i);
		}

        private static void AsIsDemo() {
            object str = "a sample string";

            if (str is String) {
                Console.WriteLine("Length: {0}.", ((string)str).Length);
                Console.WriteLine("Uppercase: {0}.", ((string)str).ToUpper());
            }

            string asString = str as string;
            if (asString != null) {
                Console.WriteLine("Length: {0}.", asString.Length);
                Console.WriteLine("ToString: {0}.", asString.ToUpper());
            }
        }

        static void Main() {
            Demo();
            AsIsDemo();
        }

	}
}
