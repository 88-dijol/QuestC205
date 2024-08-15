//4.  ComplexNumber { Real: int, Imaginary: int}
//using ComplexNumberProject;

//-ComplexNumber Add(ComplexNumber other)
//    TestComplexNumber for addition 
//        (3 + i4)
//     +  (5 + i3) 
//     =  (8 + i7)




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberProject
{

    class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public ComplexNumber(int _real , int _imaginary)
        {
            this.Real = _real;
            this.Imaginary = _imaginary;

        }

        public ComplexNumber ComplexNumberAdd(ComplexNumber other)
        {
            return new ComplexNumber(this.Real + other.Real, this.Imaginary + other.Imaginary);
        }

        public override string ToString()
        {
            return $"[ComplexNumber={Real} + i{Imaginary}]";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber firstNumber = new ComplexNumber(3, 4);
            ComplexNumber secondNumber = new ComplexNumber(5, 3);
            ComplexNumber result = firstNumber.ComplexNumberAdd(secondNumber);
            Console.WriteLine($"\nResult of addition: {result}");





        }
    }
}

//op:Result of addition: [ComplexNumber=8 + i7]

