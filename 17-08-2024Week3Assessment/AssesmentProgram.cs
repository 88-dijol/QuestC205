﻿

//Question 1 of 1
//Create a `SurgicalProcedure` Class with Comparison Methods
//- Task: Implement a class `SurgicalProcedure` that represents
//a surgical procedure with properties `ProcedureID` and `Cost` (in dollars).
//Implement the following methods:
//`Equals`, `NotEquals`, `GreaterThan`,
//`GreaterThanEquals`, `LessThan`, and `LessThanEquals`
//to compare the costs of two surgical procedures.
//- Requirements:
//-Implement the `Equals(SurgicalProcedure other)` method to check
//if two procedures have the same cost.
//- Implement the `NotEquals(SurgicalProcedure other)` method to check
//if two procedures have different costs.
//- Implement the `GreaterThan(SurgicalProcedure other)` method to check
//if one procedure is more expensive than another.
//- Implement the `GreaterThanEquals(SurgicalProcedure other)` method to check
//if one procedure is more expensive or the same price as another.
//- Implement the `LessThan(SurgicalProcedure other)` method to check
//if one procedure is less expensive than another.
//- Implement the `LessThanEquals(SurgicalProcedure other)` method to check
//if one procedure is less expensive or the same price as another.
//- Example:
//```csharp
//SurgicalProcedure sp1 = new SurgicalProcedure("SP001", 5000);
//SurgicalProcedure sp2 = new SurgicalProcedure("SP002", 4500);

//Console.WriteLine(sp1.Equals(sp2)); // Output: False
//Console.WriteLine(sp1.GreaterThan(sp2)); // Output: True
//Console.WriteLine(sp1.LessThanEquals(sp2)); // Output: False


//ans=========================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assesment
{

    public class SurgicalProcedure
    {
        public string ProcedureID { get; set; }

        public decimal Cost { get; set; }

        public SurgicalProcedure(string procedureID, decimal cost)
        {
            this.ProcedureID = procedureID;
            this.Cost = cost;

        }

        public bool Equals(SurgicalProcedure other)
        {
            return this.Cost == other.Cost;
        }

        public bool NotEquals(SurgicalProcedure other)
        {
            return this.Cost != other.Cost;
        }

        public bool GreaterThan(SurgicalProcedure other)
        {
            return this.Cost > other.Cost;
        }

        public bool GreaterThanEquals(SurgicalProcedure other)
        {
            return this.Cost >= other.Cost;
        }


        public bool LessThan(SurgicalProcedure other)
        {
            return this.Cost < other.Cost;
        }

        public bool LessThanEquals(SurgicalProcedure other)
        {
            return this.Cost <= other.Cost;
        }

        //public override string ToString()
        //{
        //    return $"[ProcedureID={this.ProcedureID},Cost={this.Cost}]";
        //}
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            SurgicalProcedure sp1 = new SurgicalProcedure("sp131", 2000);

            SurgicalProcedure sp2 = new SurgicalProcedure("sp132", 5000);
            

            Console.WriteLine(sp1.Equals(sp2));
            Console.WriteLine(sp1.NotEquals(sp2));
            Console.WriteLine(sp1.GreaterThan(sp2));
            Console.WriteLine(sp1.GreaterThanEquals(sp2));
            Console.WriteLine(sp1.LessThan(sp2));
            Console.WriteLine(sp1.LessThanEquals(sp2));
            Console.ReadKey();

        }
    }
}

//op:========================================================================================
/// False
//True
//False
//False
//True
//True
