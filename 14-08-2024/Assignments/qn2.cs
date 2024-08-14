

//2.Circle { Radius: int }
//-float Circumference()
//- bool IsCircumferenceGt(Circle other)
//    TestCircle


using CircleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleProject
{

    class Circle
    {
        public int Radius { get; set; }

        public Circle(int _radius)
        {
            this.Radius = _radius;
        }

        public float FindCircumference()
        {
            return 2 * (float)Math.PI * Radius;
        }

        public bool IsCircumferenceGt(Circle other)
        {
            return this.FindCircumference() > other.FindCircumference();
        }

        public bool IsCircumferenceEq(Circle other)
        {
            return this.FindCircumference() == other.FindCircumference() ;
        }

        public override string ToString()
        {
            return $"[Radius={this.Radius},Circumference={this.FindCircumference()}]";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(10);
            Circle circle2 = new Circle(5);
            if (circle1.IsCircumferenceGt(circle2))
            {
                Console.WriteLine($"First circle {circle1} is greater than Second circle {circle2}");
            }
            else if (circle1.IsCircumferenceEq(circle2))
            {
                Console.WriteLine($"First circle {circle1} equals Second circle {circle2}");
            }
            else
            {
                Console.WriteLine($"First circle {circle1} is less than Second circle {circle2}");
            }
            Console.ReadKey();

        }
    }
}


//op:First circle [Radius=10,Circumference=62.83186] is greater than Second circle [Radius=5,Circumference=31.41593]
