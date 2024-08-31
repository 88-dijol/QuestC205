using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
    public class MedicationUI
    {
        private MedicationDAO medicationDAO = new MedicationDAO();

        public void CreateMedication()
        {
            Console.Write("Enter Hospital ID: ");
            int hospitalID = int.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter Medication Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Dosage: ");
            double dosage = double.Parse(Console.ReadLine());

            Medication medication = new Medication(hospitalID, doctorName, name, dosage);
            medicationDAO.Create(medication);
            Console.WriteLine("Medication created successfully.");
        }

        public void ReadMedication()
        {
            Console.Write("Enter Hospital ID: ");
            int hospitalID = int.Parse(Console.ReadLine());

            Medication medication = medicationDAO.Read(hospitalID);
            if (medication != null)
            {
                Console.WriteLine($"HospitalID: {medication.HospitalID}");
                Console.WriteLine($"Doctor Name: {medication.DoctorName}");
                Console.WriteLine($"Medication Name: {medication.Name}");
                Console.WriteLine($"Dosage: {medication.Dosage}");
            }
            else
            {
                Console.WriteLine("Medication not found.");
            }
        }

        public void UpdateMedication()
        {
            Console.Write("Enter Hospital ID: ");
            int hospitalID = int.Parse(Console.ReadLine());

            Medication medication = medicationDAO.Read(hospitalID);
            if (medication != null)
            {
                Console.Write("Enter new Doctor Name: ");
                medication.DoctorName = Console.ReadLine();
                Console.Write("Enter new Medication Name: ");
                medication.Name = Console.ReadLine();
                Console.Write("Enter new Dosage: ");
                medication.Dosage = double.Parse(Console.ReadLine());

                medicationDAO.Update(medication);
                Console.WriteLine("Medication updated successfully.");
            }
            else
            {
                Console.WriteLine("Medication not found.");
            }
        }

        public void DeleteMedication()
        {
            Console.Write("Enter Hospital ID: ");
            int hospitalID = int.Parse(Console.ReadLine());

            medicationDAO.Delete(hospitalID);
            Console.WriteLine("Medication deleted successfully.");
        }

        public void ListAllMedications()
        {
            List<Medication> medications = medicationDAO.ListAll();
            foreach (Medication medication in medications)
            {
                Console.WriteLine(medication.ToString());
            }
        }
    }

}