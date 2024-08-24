//Problem Statement: Interface and Inheritance in Hospital Equipment Management
//- Define an interface: `IServiceable` with the following methods:
//- `Service()` (void)
//- `GetServiceStatus()` (string)
//-Define a base class: `Equipment` with properties:
//- `EquipmentID` (integer), `Name` (string)
//- Define a derived class: `DiagnosticEquipment` that inherits from `Equipment` and implements `IServiceable`:
//-Additional Property: `LastServiceDate` (DateTime)
//- Implement `Service()` to update the service date.
//- Implement `GetServiceStatus()` to return whether the equipment is due for service.
//- Define another derived class: `SurgicalEquipment` that also inherits from `Equipment` and implements `IServiceable`:
//-Additional Property: `UsageCount` (integer)
//- Implement `Service()` to reset the usage count.
//- Implement `GetServiceStatus()` to return service status based on usage.
//- Tasks:
//1.Manage Equipment:
//-Read details for N `equipments` of both types (Diagnostic and Surgical).
//2. Perform Service:
//-Call `Service()` on all equipment and display the updated status.
//3. Service Status Check:
//-Implement a method to display the service status of all equipment.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_q2
{
    public interface IServiceable
    {
        void Service();
        string GetServiceStatus();

    }

    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }

        public Equipment(int  equipmentID, string name)
        {
            EquipmentID = equipmentID;
            Name = name;
        }
    }

    public class DiagnosticEquipment : Equipment, IServiceable
    {
        public DateTime LastServiceDate { get; set; }


        public DiagnosticEquipment(int equipmentID, string name, DateTime lastServiceDate) : base(equipmentID, name)
        {
            LastServiceDate = lastServiceDate;
        }

        public void Service()
        {
            LastServiceDate = DateTime.Now;
        }

        public string GetServiceStatus()
        {

            TimeSpan Lastservicediff = DateTime.Now - LastServiceDate;
            if (Lastservicediff.Days > 180) //6months
            {
                return "Due date is finished needed service";
            }
            else
            {
                return "Service done recently";
            }
        }
    }
    public class SurgicalEquipment : Equipment, IServiceable
    {
        public int UsageCount { get; set; }

        public SurgicalEquipment(int equipmentID,string name, int usageCount) : base(equipmentID, name)
        {
            UsageCount = usageCount;
        }

        //reseting the usagecount
        public void Service()
        {
            UsageCount = 0;
        }

        public string GetServiceStatus()
        {
            if (UsageCount > 50)
            {
                return "Due for service";
            }
            else
            {
                return "In good Condition";
            }

        }


    }

   
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.Write("Enter the number of equipments:");
                int N = int.Parse(Console.ReadLine());

                // 1.Manage Equipment


                Equipment[] equipments = new Equipment[N];
                Console.WriteLine("=================================Enter details for equipment ========================");
                for (int i = 0; i < N; i++)
                {

                    Console.Write("Equipment Type (1 for Diagnostic, 2 for Surgical): ");
                    int type = int.Parse(Console.ReadLine());

                    Console.Write("Equipment ID: ");
                    int equipmentID = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    if (type == 1) // Diagnostic Equipment
                    {
                        Console.Write("Last Service Date (YYYY-MM-DD): ");
                        DateTime lastServiceDate = DateTime.Parse(Console.ReadLine());

                        equipments[i] = new DiagnosticEquipment(equipmentID, name, lastServiceDate);
                    }
                    else if (type == 2) // Surgical Equipment
                    {
                        Console.Write("Usage Count: ");
                        int usageCount = int.Parse(Console.ReadLine());

                        equipments[i] = new SurgicalEquipment(equipmentID, name, usageCount);
                    }
                }



                //2. Perform Service on all equipment

                Console.WriteLine("===============================Perform Service on all equipment============================");
                foreach (var equipment in equipments)
                {
                    if (equipment is IServiceable serviceable)
                    {
                        serviceable.Service();
                        Console.WriteLine($"Equipment ID: {equipment.EquipmentID}, Name: {equipment.Name} has been serviced.");
                    }
                }

                //3.Service Status of all equipment
                Console.WriteLine("============================Service Status of all equipment==================================");
         
                foreach (var equipment in equipments)
                {
                    if (equipment is IServiceable serviceable)
                    {
                        string status = serviceable.GetServiceStatus();
                        Console.WriteLine($"Equipment ID: {equipment.EquipmentID}, Name: {equipment.Name}, Status: {status}");
                    }
                }
            }
        }
    }
}
