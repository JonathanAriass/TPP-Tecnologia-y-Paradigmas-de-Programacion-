using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    class Query {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection) {
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args) {
            Query query = new Query();
            query.Query2a();
            query.Query2b();
            query.Query2c();
            query.Query3();
            query.Query4a();
            query.Query4b();
            query.Query4c();
            query.Query5();
            query.Query6();
        }

        private void Query1() {
            // Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees.Where(e => e.Age>50).Select(e => e.Name);
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private class NameAndEmail
        {
            public string Name { get; set; }
            public string Email { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Email: {Email}";
            }
        }


        private void Query2a() {
            // Show the name and email of the employees who work in Asturias con clase 
            var employees = model.Employees
                .Where(e => e.Province.ToLower().Equals("asturias"))
                .Select(e => new NameAndEmail { Name = e.Name, Email = e.Email });


            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Query2b()
        {
            // Show the name and email of the employees who work in Asturias con clase anonima y elementos anonimos
            var employees = model.Employees
                .Where(e => e.Province.ToLower().Equals("asturias"))
                .Select(e => new { e.Name, e.Email });


            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Query2c()
        {
            // Show the name and email of the employees who work in Asturias con tuplas
            var employees = model.Employees
                .Where(e => e.Province.ToLower().Equals("asturias"))
                .Select(e => ( e.Name, e.Email ));


            Console.WriteLine("Employees:");
            Show(employees);
        }

        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3() {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"
            var department = model.Departments
                .Where(d => d.Employees.Where(e => e.Age >= 18).Count() > 1)
                .Where(d => d.Employees.Any(e => e.Office.Number.StartsWith("2.1")))
                .Select(d => d.Name);

            Console.WriteLine("Departments:");
            Show(department);
        }

        private void Query4a() {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var phoneCalls = model.PhoneCalls
                .Where(p => model.Employees.Any(e => e.TelephoneNumber.Equals(p.SourceNumber)))
                .Select(p => new { 
                    Employee = model.Employees.First(e => e.TelephoneNumber.Equals(p.SourceNumber)).Name,
                    Duration = p.Seconds
                });
            Console.WriteLine("Llamadas:");
            Show(phoneCalls);
        }
        private void Query4b()
        {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var calls = model.Employees
                .SelectMany(e => model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber))) // El SelectMany lo que hace es concatenar las listas para bajar la dimension
                .Select(p => new {
                    Employee = model.Employees.First(e => e.TelephoneNumber.Equals(p.SourceNumber)).Name,
                    Duration = p.Seconds
                });
            Console.WriteLine("Llamadas:");
            Show(calls);
        }

        // Se hace con join para bajar la complejidad O(n**2) de las anteriories versiones a O(n) (mas o menos)
        // Con el join el numero tiene que ser el mismo y no hace falta hacer el select comparando el numero del empleado
        // con el numero de la llamada
        private void Query4c()
        {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var calls = model.Employees.Join(model.PhoneCalls,
                e => e.TelephoneNumber,
                p => p.SourceNumber,
                (e, p) => new
                {
                    Employee = e.Name,
                    Duration = p.Seconds,
                });
            Console.WriteLine("Llamadas:");
            Show(calls);
        }

        private void Query5() {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)
            var employeesByProvince = model.Employees
                .OrderBy(e => e.Name.ToLower())
                .GroupBy(e => e.Province.ToLower())
                .OrderBy(grouping => grouping.Key.ToLower());

            Console.WriteLine("Empleados por provincia:");
            foreach (var provinceEmployees in employeesByProvince) 
            {
                Console.WriteLine(provinceEmployees.Key);
                // Los IGrouping no tienen .Value, por lo que hay que hacer un iterador para el valor
                foreach (var e in provinceEmployees) 
                {
                    Console.WriteLine($"    {e.Name}");
                }
            }
        }

        private void Query6() 
        {
            var i = 0;
            // Muestrame las llamadas ordenadas por duracion (mas a menos) con un ranking (por numeros)
            ///var llamadas = model.PhoneCalls
            /// .OrderByDescending(p => p.Seconds)
            ///.Select(p => $"Rank: {i++}  Duration: {p.Seconds}");

            var llamadas = model.PhoneCalls
                .OrderByDescending(p => p.Seconds)
                .Zip(Enumerable.Range(1, model.PhoneCalls.Count() + 1), 
                    (c,i) => $"Rank: {i++}  p.Seconds)");
            Console.WriteLine("Llamadas: ");
            Show(llamadas);
        }

        /************ Homework **********************************/

        private void Homework1() {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute
        }

        private void Homework2() {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
        }

        private void Homework3() {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”
        }

        private void Homework4() {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)
        }

        private void Homework5() {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)
        }


    }

    
}
