using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($" Sum:{sum}, Average:{avg}");
            Console.WriteLine();
            Console.WriteLine();
            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num =>num);
            Console.WriteLine("Ascending");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Decsending");
            var dsc = numbers.OrderByDescending(num =>num);
           foreach (var num in dsc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine();
            //Print to the console only the numbers greater than 6
            Console.WriteLine(" Greater than Six");
            var greaterThanSix = numbers.Where(num => num > 6);
            foreach (var item in numbers.Where(num=> num>6))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine(" First 4 Acsending");
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine("First 4 Descending");
            foreach (var num in dsc.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Index change with age");
            numbers[4]= 30;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')). OrderBy(person => person.FirstName);

            Console.WriteLine(" C or S employees");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();
            Console.WriteLine();
            //get is read only


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp=> emp.YearsOfExperience);
            Console.WriteLine("Over 26");
            foreach(var person in overTwentySix)
            {
                Console.WriteLine($" Name: {person.FullName}| Age:{person.Age} yrs.|YOE:{person.YearsOfExperience} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Sum and Average of YOE");
            var yoe = employees.Where(a => a.YearsOfExperience <= 10 && a.Age > 35);
            Console.WriteLine($"Sum:{yoe.Sum(emp=> emp.YearsOfExperience)}| Avg: {yoe.Average(emp=> emp.YearsOfExperience)}");

            Console.WriteLine();
            Console.WriteLine();
            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine(" Type First Name, Last Name, Age, and Years of Experience. Hit enter after each entry");
            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            var newAge = int.Parse(Console.ReadLine());
            var newYOE = int.Parse(Console.ReadLine());

            employees = employees.Append(new Employee (firstName, lastName, newAge, newYOE)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName}, {emp.Age}");
            }

            Console.WriteLine();
            Console.ReadLine();
            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 43));
            employees.Add(new Employee("Jill", "Valentine", 32, 22));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
