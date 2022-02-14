using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    class Program {

        static void Main(string[] args) {
            string paragraph = @"
                In 2008, the University of Oviedo celebrated its 400th Anniversary. 
                Since it was founded by the Archbishop Valdés Salas, it has kept its 
                commitment to service to Asturias according to the core values of the 
                society throughout History. In this day and age, the University of 
                Oviedo, one of the oldest in Spain, ratifies its commitment to the 
                social, cultural and economic development of our region.";
            Console.WriteLine("Number of words in the paragraph: {0}.", paragraph.CountWords());
        }
    }


}
