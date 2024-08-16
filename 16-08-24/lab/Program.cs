using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{

    enum Convertion
    {
        Upper,
        Lower,
        Trim
    }

    internal class Program
    {
        static void Convert(string text, Convertion action)
        {
            // Using if-else to perform the conversion
            if (action == Convertion.Upper)
                Console.WriteLine(text.ToUpper());
            else if (action == Convertion.Lower)
                Console.WriteLine(text.ToLower());
            else if (action == Convertion.Trim)
                Console.WriteLine(text.Trim());

            // Using switch to perform the conversion
            switch (action)
            {
                case Convertion.Upper:
                    Console.WriteLine(text.ToUpper());
                    break;
                case Convertion.Lower:
                    Console.WriteLine(text.ToLower());
                    break;
                case Convertion.Trim:
                    Console.WriteLine(text.Trim());
                    break;
                default:
                    break;
            }
        }

        static void Main()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.WriteLine("1. To Upper");
            Console.WriteLine("2. To Lower");
            Console.WriteLine("3. To Trim");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Convertion action;

            switch (choice)
            {
                case 1:
                    action = Convertion.Upper;
                    break;
                case 2:
                    action = Convertion.Lower;
                    break;
                case 3:
                    action = Convertion.Trim;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Convert(input, action);
        }
    }