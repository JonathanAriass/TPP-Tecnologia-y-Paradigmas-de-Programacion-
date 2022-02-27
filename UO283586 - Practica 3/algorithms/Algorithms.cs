
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    static class Algorithms {

        // Exercise: Implement an IndexOf method that finds the first position (index) 
        // of an object in an array of objects. It should be valid for Person, Angle and future classes.

        // El interrogate signifuca que es nulleable y se puede devolver null
        public static int? IndexOf(this object[] elements, object target)
        {
            int counter = 0;
            foreach (Object obj in elements)
            {
                if (obj.Equals(target))
                {
                    return counter;
                }
                counter++;
            }
            return null;
        }

        public static int? IndexOf2(this object[] elements, object target, IEqualityPredicate predicate=null)
        {
            int counter = 0;
            foreach (Object obj in elements)
            {
                if (Compare(obj, target, predicate))
                {
                    return counter;
                }
                counter++;
            }
            return null;
        }

        private static bool Compare(object obj, object target, IEqualityPredicate predicate)
        {
            if (predicate == null)
            {
                return obj.Equals(target);
            }
            return predicate.Compare(obj, target);
        }

        static Person[] CreatePeople() {
            string[] firstnames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numberOfPeople = 100;

            Person[] printOut = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printOut[i] = new Person(
                    firstnames[random.Next(0, firstnames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printOut;
        }

        static Angle[] CreateAngles() {
            Angle[] angles = new Angle[(int)(Math.PI * 2 * 10)];
            int i = 0;
            while (i < angles.Length) {
                angles[i] = new Angle(i / 10.0);
                i++;
            }
            return angles;
        }

        static void Main() {
            // To be done by the student
            var people = CreatePeople();
            var person0 = new Person(people[75].FirstName, people[75].SurName, people[75].IDNumber);
            var idxPerson = people.IndexOf(person0);
            if (idxPerson.HasValue)
            { 
                Console.WriteLine($"person0 = {idxPerson}");
                Console.WriteLine($"people[{idxPerson.Value}] = {people[idxPerson.Value]}");
            }


            var angles = CreateAngles();
            var angle0 = new Angle(angles[50].Radians);
            var idxAngle = angles.IndexOf(angle0);
            if (idxAngle.HasValue)
            {
                Console.WriteLine($"angle0 = {idxAngle}");
                Console.WriteLine($"angles[{idxAngle.Value}] = {angles[idxAngle.Value]}");
            }


            var idxPerson2 = people.IndexOf2(person0, predicate: new SameFirstName());
            if (idxPerson2.HasValue)
            {
                Console.WriteLine($"person2 = {idxPerson2}");
                Console.WriteLine($"people[{idxPerson2.Value}] = {people[idxPerson2.Value]}");
            }

            var idxAngle2 = angles.IndexOf2(angle0, predicate: new SameCuadrant());
            if (idxAngle2.HasValue)
            {
                Console.WriteLine($"angle0 = {idxAngle2}");
                Console.WriteLine($"angles[{idxAngle2.Value}] = {angles[idxAngle2.Value]}");
            }

        }

    }

    internal class SameCuadrant : IEqualityPredicate
    {
        public bool Compare(object obj, object target)
        {
            Angle a1 = obj as Angle;
            if (a1 == null)
            {
                return false;
            }
            Angle a2 = target as Angle;
            if (a2 == null)
            {
                return false;
            }
            return Quadrant(a1.Radians) == Quadrant(a2.Radians);
        }

        private int Quadrant(double radians)
        {
            if (radians > 2 * Math.PI)
            {
                return Quadrant(radians % (2 * Math.PI));
            }
            if (radians < 0)
            {
                return Quadrant(radians + Math.PI);
            }

            if (radians < (Math.PI / 2))
            {
                return 1;
            }
            if (radians < Math.PI)
            {
                return 2;
            }
            if (radians < (Math.PI*3/ 2))
            {
                return 3;
            }
            return 4;
        }
    }

    internal class SameFirstName : IEqualityPredicate
    {
        public SameFirstName()
        {
        }

        public bool Compare(object obj, object target)
        {
            Person p1 = obj as Person;
            if (p1 == null)
            {
                return false;
            }
            Person p2 = obj as Person;
            if (p2 == null)
            {
                return false;
            }

            return p1.FirstName.Equals(p2.FirstName);
        }
    }

    internal interface IEqualityPredicate
    {
        bool Compare(object obj, object target);
    }
}
