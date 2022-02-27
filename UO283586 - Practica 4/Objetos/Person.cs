using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03
{

    /// <summary>
    /// Person class used in different examples
    /// </summary>
    public class Person
    {

        private String firstName, surname;

        public String FirstName
        {
            get { return firstName; }
        }
        public String Surname
        {
            get { return surname; }
        }

        private string idNumber;
        public string IDNumber
        {
            get { return idNumber; }
        }

        public override String ToString()
        {
            return String.Format("{0} {1}, with {2} ID number", firstName, surname, idNumber);
        }

        public Person(String firstName, String surname, string idNumber)
        {
            this.firstName = firstName;
            this.surname = surname;
            this.idNumber = idNumber;
        }

        public override bool Equals(object obj)
        {
            var p1 = obj as Person;

            if (p1 == null)
            {
                return false;
            }


            if (p1.FirstName.Equals(this.FirstName) &&
                p1.surname.Equals(this.surname) &&
                p1.idNumber.Equals(this.idNumber))
            {
                return true;
            }
            return false;
        }
    }
}