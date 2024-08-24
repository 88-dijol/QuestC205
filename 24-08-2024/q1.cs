//qn1

//Problem Statement: Hospital Medication Management
//- Define a class: `HospitalMedication` with the following properties:
//- `HospitalID` (integer)
//- `DoctorName` (string)
//- `Medication` (string)
//- `Dosage` (double, in milligrams)
//- Tasks:
//1.Data Entry:
//-Read N `hospitalMedications` from the keyboard.
//2. Find Maximum Dosage by a Specific Doctor:
//-For a given doctor's name, display the medication with the highest dosage prescribed by them.
//Solve in time complexity of O(N).
//Dont use built-in C# sorting or LINQ.
//3. Find Second Least Dosage Overall:
//-Display the medication with the second least dosage across all hospitals.
//Solve in time complexity of O(N).
//Dont use built-in C# sorting or LINQ.
//4. Sort by Medication Name:
//-Implement and call your own sorting algorithm.
//Dont use built-in C# sorting or LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ExamQ1
{
    public class HospitalMedication
    {
        public int HospitalID { get; set; }

        public string DoctorName { get; set; }

        public string Medication { get; set; }

        public double Dosage { get; set; }

        public HospitalMedication(int hospitalID, string doctorName, string medication, double dosage)
        {
            HospitalID = hospitalID;
            DoctorName = doctorName;
            Medication = medication;
            Dosage = dosage;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Hospital Medications:");

            int n = int.Parse(Console.ReadLine());

            HospitalMedication[] hospitalMedications = new HospitalMedication[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the HospitalID:");
                int hospitalID = int.Parse(Console.ReadLine());

                Console.Write("Enter the DoctorName:");
                string doctorName = Console.ReadLine();

                Console.Write("Enter the Medication:");
                string medication = Console.ReadLine();

                Console.Write("Enter the Dosage in milligrams:");
                double dosage = double.Parse(Console.ReadLine());

                hospitalMedications[i] = new HospitalMedication(hospitalID, doctorName, medication, dosage);


            }

            //Find Maximum Dosage by a Specific Doctor
            Console.WriteLine("------------------MAXIMUM DOSAGE BY A SPECIFIC DOCTOR--------------------------------------");


            Console.Write("Enter the Doctor name to find the maximum dosage of that doctor:");
            string doctorNameforMaxDosage = Console.ReadLine();

            HospitalMedication maxDosageMedication = FindMaxDosageByDoctor(hospitalMedications, doctorNameforMaxDosage);
            if (maxDosageMedication != null)
            {
                Console.WriteLine($"Medication with maximum dosage by {doctorNameforMaxDosage} with {maxDosageMedication.Medication},{maxDosageMedication.Dosage}milligram");
            }
            else
            {
                Console.WriteLine($"No medication found for {doctorNameforMaxDosage}");
            }

            //Find Second Least Dosage Overall:

            Console.WriteLine("--------------------------SECOND LEAST DOSAGE OVERALL---------------------------------------------");

            HospitalMedication secondLeastDosage = FindSecondLeastDosageOverall(hospitalMedications);

            if (secondLeastDosage != null)
            {
                Console.WriteLine($"Medication with second least dosage overall: {secondLeastDosage.Medication} of {secondLeastDosage.Dosage} milligram");
            }
            else
            {
                Console.WriteLine("No medications found");
            }
            Console.WriteLine("--------------------------SORT BY MEDICATION NAME-------------------------------------------");
            HospitalMedication[] sortedMedications = SortByMedicationName(hospitalMedications);
            Console.WriteLine("Medications sorted by name:");
            foreach (HospitalMedication medication in sortedMedications)
            {
                Console.WriteLine($"{medication.Medication} of {medication.Dosage} milligram");
            }
        }
        public static HospitalMedication FindMaxDosageByDoctor(HospitalMedication[] hospitalMedications, string doctorName)
        {
            HospitalMedication maxDosageMedication = null;
            double maxDosage = 0;

            foreach (HospitalMedication medication in hospitalMedications)
            {
                if (medication.DoctorName == doctorName && medication.Dosage > maxDosage)
                {
                    maxDosageMedication = medication;
                    maxDosage = medication.Dosage;
                }
            }

            return maxDosageMedication;
        }
        public static HospitalMedication FindSecondLeastDosageOverall(HospitalMedication[] hospitalMedications)
        {
            double minDosage = double.MaxValue;
            double secondMinDosage = double.MaxValue;
            HospitalMedication secondLeastDosageMedication = null;

            foreach (HospitalMedication medication in hospitalMedications)
            {
                if (medication.Dosage < minDosage)
                {
                    secondMinDosage = minDosage;
                    minDosage = medication.Dosage;
                    secondLeastDosageMedication = medication;
                }
                else if (medication.Dosage < secondMinDosage && medication.Dosage != minDosage)
                {
                    secondMinDosage = medication.Dosage;
                    secondLeastDosageMedication = medication;
                }
            }

            return secondLeastDosageMedication;
        }

        //sorting
        public static HospitalMedication[] SortByMedicationName(HospitalMedication[] hospitalMedications)
        {
           
            for (int i = 0; i < hospitalMedications.Length - 1; i++)
            {
                for (int j = i + 1; j < hospitalMedications.Length; j++)
                {
                    if (string.Compare(hospitalMedications[i].Medication, hospitalMedications[j].Medication) > 0)
                    {
                        HospitalMedication temp = hospitalMedications[i];
                        hospitalMedications[i] = hospitalMedications[j];
                        hospitalMedications[j] = temp;
                    }
                }
            }

            return hospitalMedications;
        }
    }
}



//Output:
//Enter the number of Hospital Medications:7
//Enter the HospitalID:123
//Enter the DoctorName:Sajay
//Enter the Medication:Paracetamol
//Enter the Dosage in milligrams:650
//Enter the HospitalID:234
//Enter the DoctorName:Sukumar
//Enter the Medication:Dolo
//Enter the Dosage in milligrams:600
//Enter the HospitalID:123
//Enter the DoctorName:Sajay
//Enter the Medication:Aspirin
//Enter the Dosage in milligrams:150.5
//Enter the HospitalID:234
//Enter the DoctorName:Sukumar
//Enter the Medication:Amoxicilin
//Enter the Dosage in milligrams:300
//Enter the HospitalID:123
//Enter the DoctorName:Dhanya
//Enter the Medication:Atenolol
//Enter the Dosage in milligrams:705.5
//Enter the HospitalID:123
//Enter the DoctorName:Sajay
//Enter the Medication:Dolo
//Enter the Dosage in milligrams:400
//Enter the HospitalID:234
//Enter the DoctorName:Sukumar
//Enter the Medication:Paracetamol
//Enter the Dosage in milligrams:750
//------------------MAXIMUM DOSAGE BY A SPECIFIC DOCTOR--------------------------------------
//Enter the Doctor name to find the maximum dosage of that doctor:Sajay
//Medication with maximum dosage by Sajay with Paracetamol,650milligram
//--------------------------SECOND LEAST DOSAGE OVERALL---------------------------------------------
//Medication with second least dosage overall: Amoxicilin of 300 milligram
//--------------------------SORT BY MEDICATION NAME-------------------------------------------
//Medications sorted by name:
//Amoxicilin of 300 milligram
//Aspirin of 150.5 milligram
//Atenolol of 705.5 milligram
//Dolo of 600 milligram
//Dolo of 400 milligram
//Paracetamol of 650 milligram
//Paracetamol of 750 milligram






