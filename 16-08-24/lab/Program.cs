﻿


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePro
{
    class Employee

    {

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public override string ToString()

        {

            return $"Name: {Name} {Environment.NewLine}" +

                $"Email: {Email} {Environment.NewLine}" +

                $"Age: {Age}";

        }

    }

    class EmployeeAdd
    {

        private Employee[] _employees = new Employee[10];

        private int _count = 0;


        public void Add()
        {
            var emp = new Employee();

            Console.Write("Name: ");

            emp.Name = Console.ReadLine();

            Console.Write("Email: ");

            emp.Email = Console.ReadLine();

            Console.Write("Age: ");

            emp.Age = int.Parse(Console.ReadLine());

            _employees[_count] = emp;

            _count++;
        }

        public void Search()
        {
            Console.WriteLine("Email: ");

            var email = Console.ReadLine();

            for (int i = 0; i < _count; i++)

            {

                var e = _employees[i];

                if (e.Email == email)

                {

                    Console.WriteLine(e);

                    break;

                }

            }
        }

    }

    internal class Program

    {

        static void Main()

        {
            var manager = new EmployeeAdd();

            while (true)

            {

                Console.WriteLine("1. Add new employee");

                Console.WriteLine("2. Search employee");

                Console.Write("Please enter your option: ");

                var option = Console.ReadLine();

                switch (option)

                {

                    case "1":

                        manager.Add();

                        break;

                    case "2":

                        manager.Search();

                        break;

                    default:

                        Console.WriteLine("Invalid option");

                        break;

                }

            }

        }

    }

}


//    class Employee
//    {
//            public string Name { get; set; }
//            public string Email { get; set; }
//            public int Age { get; set; }

//            public override string ToString()
//            {
//                return $"Name: {Name} {Environment.NewLine}" +
//                    $"Email: {Email} {Environment.NewLine}" +
//                    $"Age: {Age}";
//            }
//    }

//    internal class Program

//    {

//        static void Main()

//        {

//            var employees = new Employee[10];

//            int count = 0;

//            while (true)

//            {

//                Console.WriteLine("1. Add new employee");

//                Console.WriteLine("2. Search employee");

//                Console.Write("Please enter your option: ");

//                var option = Console.ReadLine();

//                switch (option)

//                {

//                    case "1":

//                        var emp = new Employee();

//                        Console.Write("Name: ");

//                        emp.Name = Console.ReadLine();

//                        Console.Write("Email: ");

//                        emp.Email = Console.ReadLine();

//                        Console.Write("Age: ");

//                        emp.Age = int.Parse(Console.ReadLine());

//                        employees[count] = emp;

//                        count++;

//                        break;

//                    case "2":

//                        Console.WriteLine("Email: ");

//                        var email = Console.ReadLine();

//                        for (int i = 0; i < count; i++)

//                        {

//                            var e = employees[i];

//                            if (e.Email == email)

//                            {

//                                Console.WriteLine(e);

//                                break;

//                            }

//                        }

//                        break;

//                    default:

//                        Console.WriteLine("Invalid option");

//                        break;

//                }

//            }

//        }

//    }

//}

//op:
//1. Add new employee
//2.Search employee
//Please enter your option: 1
//Name: Dijol
//Email: dijoldavis00 @gmail.com
//Age: 23
//1.Add new employee
//2.Search employee
//Please enter your option: 2
//Email:
//dijoldavis00 @gmail.com
//Name: Dijol
//Email: dijoldavis00 @gmail.com
//Age: 23
//1.Add new employee
//2.Search employee
//Please enter your option: 3
//Invalid option
//1. Add new employee
//2.Search employee
//Please enter your option:

