using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.Functional.Lab05
{
    [TestClass]
    public class TareaTest
    {

        Person[] people;
        Angle[] angles;

        [TestInitialize]
        public void Initialize() 
        {
            people = Factory.CreatePeople();
            angles = Factory.CreateAngles();
        }

        [TestMethod]
        public void FindPeopleTest()
        {
            // Test con Find() de C#
            Person person = Array.Find(people, x=>x.FirstName.Equals("Pepe") && x.IDNumber.EndsWith('R'));
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");

            person = Array.Find(people, x => x.FirstName.Equals("María") && x.IDNumber.EndsWith('A'));
            Assert.AreEqual(person.FirstName, "María");
            Assert.AreEqual(person.Surname, "Díaz");
            Assert.AreEqual(person.IDNumber, "9876384A");

            // Test con funcion lambda
            person = Algorithm.Buscar(people, x => x.FirstName.Equals("Pepe") && x.IDNumber.EndsWith('R'));
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");

            // Test con Func<>
            Func<Person,bool> find = Algorithm.BuscarLetra;

            person = Algorithm.Buscar(people, find);
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");


            // Test con el Predicate<>
            Predicate<Person> buscar = Algorithm.BuscarLetra;
            person = Algorithm.BuscarPred(people, buscar);
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");
        }


        [TestMethod]
        public void FindStraightAngleTest()
        {
            // Test con Find() de C#
            Angle angle = Array.Find(angles, x => x.Quadrant.Equals(1) && x.Degrees == 90);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);

            angle = Algorithm.Buscar(angles, x => x.Quadrant.Equals(3) && x.Degrees == 220);
            Assert.AreEqual(220, angle.Degrees);
            Assert.AreEqual(3, angle.Quadrant);

            // Test con Func<>
            Func<Angle, bool> find = Algorithm.BuscarAngulo;
            angle = Algorithm.Buscar(angles, find);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);

            // Test con Predicate
            Predicate<Angle> buscar = Algorithm.BuscarAngulo;
            angle = Algorithm.BuscarPred(angles, buscar);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);
        }


        [TestMethod]
        public void FilterPeopleTest()
        {
            Func<Person, bool> aux = x => x.IDNumber.EndsWith('A');
            Person[] personAux = Algorithm.Filtrar(people, aux);
            Assert.AreEqual("María", personAux[0].FirstName);
            Assert.AreEqual("Luis", personAux[1].FirstName);
        }

        [TestMethod]
        public void FilterAngleTest()
        {
            Func<Angle, bool> aux1 = x => x.Degrees <= 90 && x.Quadrant.Equals(1);
            Angle[] angleAux = Algorithm.Filtrar(angles, aux1);
            int angle = 0;
            foreach (Angle an in angleAux)
            {
                Assert.AreEqual(angle, an.Degrees);
                angle++;
            }
            /* Saldrian 91 grados, puesto que la ultima vez que se hace el foreach se comprueba
            *  que el angulo sea 90 y se suma uno mas al contador, es decir, acaba en 91.
            *  Una forma de solucionar esto es restarle uno cuando lo imprimamos para ver el contenido.
            */
            Console.WriteLine(angle-1);
        }
    }
}
