using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Week4AssessmentApp
{
    
        internal class Program
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(Program));

            static void Main(string[] args)
            {
                log4net.Config.XmlConfigurator.Configure();

                MedicationUI ui = new MedicationUI();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\nMedication Management System");
                    Console.WriteLine("1. Create Medication");
                    Console.WriteLine("2. Read Medication");
                    Console.WriteLine("3. Update Medication");
                    Console.WriteLine("4. Delete Medication");
                    Console.WriteLine("5. List All Medications");
                    Console.WriteLine("6. Exit");

                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ui.CreateMedication();
                            break;
                        case "2":
                            ui.ReadMedication();
                            break;
                        case "3":
                            ui.UpdateMedication();
                            break;
                        case "4":
                            ui.DeleteMedication();
                            break;
                        case "5":
                            ui.ListAllMedications();
                            break;
                        case "6":
                            running = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }

    //public class ServerException : Exception
    //{
    //    public ServerException(string message) : base(message) { }
    //}
    //public class HospitalMedication
    //{
    //    public int HospitalID { get; set; }

    //    public string DoctorName { get; set; }

    //    public string Medication { get; set; }

    //    public double Dosage { get; set; }

    //    public override string ToString()
    //    {
    //        return $"[{HospitalID},{DoctorName},{Medication},{Dosage}]";
    //    }
    //}

    //public class HospitalMedicationService
    //{
    //    public static void Read(HospitalMedication[] hospitalMedications)
    //    {
    //        try
    //        {
    //            using (SqlConnection conn = new SqlConnection(connectionString))
    //            {
    //                string query = "SELECT HospitalID, DoctorName, Medication,Dosage FROM HospitalMedication";
    //                SqlCommand cmd = new SqlCommand(query, conn);

    //                conn.Open();
    //                SqlDataReader reader = cmd.ExecuteReader();
    //                for (int i = 0; i < hospitalMedications.Length; i++)
    //                {
    //                    if (!reader.Read())
    //                    {
    //                        throw new ServerException("[0101]Server Errror.");//throw error
    //                    }
    //                    hospitalMedications[i] = new HospitalMedication
    //                    {
    //                        HospitalID = (int)reader["HospitalID"],
    //                        DoctorName = reader["DoctorName"].ToString(),
    //                        Medication = reader["Medication"].ToString(),
    //                        Dosage = (double)reader["Dosage"]
    //                    };
    //                }
    //            }

    //        }
    //        catch (SqlException ex)
    //        {
    //            // Handle SQL exceptions
    //            //Console.WriteLine($"SQL Error: {ex.Message}");
    //            throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
    //        }
    //        catch (ServerException ex)
    //        {
    //            throw ex;
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle other exceptions
    //            //Console.WriteLine($"Error: {ex.Message}");
    //            throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
    //        }
    //    }
    //    public static void Sort(HospitalMedication[] hospitalMedications)
    //    {
    //        int n = hospitalMedications.Length;
    //        for (int i   = 0; i < n - 1; i++)
    //        {
    //            int minIndex = i;
    //            for (int j = i + 1; j < n; j++)
    //            {
    //                if (string.Compare(hospitalMedications[j].Medication, hospitalMedications[minIndex].Medication) < 0)
    //                {
    //                    minIndex = j;
    //                }
    //            }

    //            HospitalMedication temp = hospitalMedications[minIndex];
    //            hospitalMedications[minIndex] = hospitalMedications[i];
    //            hospitalMedications[i] = temp;
    //        }

    //    }
    //    public static HospitalMedication FindMax(HospitalMedication[] hospitalMedications, string doctorName)
    //    {

    //        HospitalMedication maxDosageMedication = null;
    //        double maxDosage = 0;

    //        foreach (HospitalMedication medication in hospitalMedications)
    //        {
    //            if (medication.DoctorName == doctorName && medication.Dosage > maxDosage)
    //            {
    //                maxDosageMedication = medication;
    //                maxDosage = medication.Dosage;
    //            }
    //        }

    //        return maxDosageMedication;



    //    }
    //    public static HospitalMedication FindSecondMin(HospitalMedication[] hospitalMedications)
    //    {
    //        double minDosage = double.MaxValue;
    //        double secondMinDosage = double.MaxValue;
    //        HospitalMedication secondLeastDosageMedication = null;

    //        foreach (HospitalMedication medication in hospitalMedications)
    //        {
    //            if (medication.Dosage < minDosage)
    //            {
    //                secondMinDosage = minDosage;
    //                minDosage = medication.Dosage;
    //                secondLeastDosageMedication = medication;
    //            }
    //            else if (medication.Dosage < secondMinDosage && medication.Dosage != minDosage)
    //            {
    //                secondMinDosage = medication.Dosage;
    //                secondLeastDosageMedication = medication;
    //            }
    //        }

    //        return secondLeastDosageMedication;



    //    }

    //}
    //public class Program
    //{
    //    private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    //    static void Main(string[] args)
    //    {
    //        HospitalMedication[] hospitalMedications = new HospitalMedication[3];
    //        try
    //        {
    //            HospitalMedicationService.Read(hospitalMedications);
    //        }
    //        catch (ServerException ex)
    //        {
    //            log.Error($"{ex.Message}");
    //            //Console.WriteLine($"{ex.Message}");
    //        }
    //        log.Info("Enter the Doctor name to find the maximum dosage of that doctor:");
    //        //Console.WriteLine("Enter the Doctor name to find the maximum dosage of that doctor:");
    //        string doctorNameforMaxDosage = "Sanjay";
    //        HospitalMedication max = HospitalMedicationService.FindMax(hospitalMedications, doctorNameforMaxDosage);
    //        log.Info($"max = {max}");
    //        //Console.WriteLine($"max = {max}");
    //        HospitalMedication secondMin = HospitalMedicationService.FindSecondMin(hospitalMedications);
    //        log.Info($"secondMin = {secondMin}");
    //        //Console.WriteLine($"secondMin = {secondMin}");
    //        HospitalMedicationService.Sort(hospitalMedications);
    //        string output = "";
    //        foreach(var h in hospitalMedications)
    //        {
    //            output+= $"{h}";


    //        }
    //        log.Info(output);
    //        //Console.WriteLine(output);

    //        }
    //    }
    //}
    //=======================================================================================================================
    //        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4Assessment;Integrated Security=True;";
    //        private static ArrayList hospitalMedications = new ArrayList();
    //        public static void Create(HospitalMedication medication)
    //        {
    //            hospitalMedications.Add(medication);

    //        }

    //        public static void ReadFromDatabase()
    //        {
    //            try
    //            {
    //                using (SqlConnection conn = new SqlConnection(connectionString))
    //                {
    //                    string query = "SELECT HospitalID, DoctorName, Medication, Dosage FROM HospitalMedication";
    //                    SqlCommand cmd = new SqlCommand(query, conn);
    //                    conn.Open();
    //                    SqlDataReader reader = cmd.ExecuteReader();
    //                    hospitalMedications.Clear();
    //                    while (reader.Read())
    //                    {
    //                        hospitalMedications.Add(new HospitalMedication
    //                        {
    //                            HospitalID = (int)reader["HospitalID"],
    //                            DoctorName = reader["DoctorName"].ToString(),
    //                            Medication = reader["Medication"].ToString(),
    //                            Dosage = (double)reader["Dosage"]
    //                        });
    //                    }
    //                }
    //            }
    //            catch (SqlException ex)
    //            {
    //                throw new ServerException($"[0102]Server Error. {ex.Message}");
    //            }
    //            catch (ServerException ex)
    //            {
    //                throw ex;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new ServerException($"[0103]Server Error. {ex.Message}");
    //            }
    //        }

    //        public static void Update(int index, HospitalMedication medication)
    //        {
    //            if (index >= 0 && index < hospitalMedications.Count)
    //            {
    //                hospitalMedications[index] = medication;

    //            }
    //            else
    //            {
    //                throw new ArgumentOutOfRangeException("Invalid index");
    //            }
    //        }

    //        public static void Delete(int index)
    //        {
    //            if (index >= 0 && index < hospitalMedications.Count)
    //            {
    //                hospitalMedications.RemoveAt(index);

    //            }
    //            else
    //            {
    //                throw new ArgumentOutOfRangeException("Invalid index");
    //            }
    //        }
    //        public static List<HospitalMedication> GetMedications()
    //        {
    //            return hospitalMedications.Cast<HospitalMedication>().ToList();
    //        }

    //        public static void Sort()
    //        {
    //            hospitalMedications.Sort(new MedicationComparer());
    //        }

    //        public static HospitalMedication FindMax(string doctorName)
    //        {
    //            HospitalMedication maxDosageMedication = null;
    //            double maxDosage = 0;

    //            foreach (HospitalMedication medication in hospitalMedications)
    //            {
    //                if (medication.DoctorName == doctorName && medication.Dosage > maxDosage)
    //                {
    //                    maxDosageMedication = medication;
    //                    maxDosage = medication.Dosage;
    //                }
    //            }

    //            return maxDosageMedication;
    //        }

    //        public static HospitalMedication FindSecondMin()
    //        {
    //            double minDosage = double.MaxValue;
    //            double secondMinDosage = double.MaxValue;
    //            HospitalMedication secondLeastDosageMedication = null;

    //            foreach (HospitalMedication medication in hospitalMedications)
    //            {
    //                if (medication.Dosage < minDosage)
    //                {
    //                    secondMinDosage = minDosage;
    //                    minDosage = medication.Dosage;
    //                    secondLeastDosageMedication = medication;
    //                }
    //                else if (medication.Dosage < secondMinDosage && medication.Dosage != minDosage)
    //                {
    //                    secondMinDosage = medication.Dosage;
    //                    secondLeastDosageMedication = medication;
    //                }
    //            }

    //            return secondLeastDosageMedication;
    //        }
    //    }

    //    public class MedicationComparer : IComparer
    //    {
    //        public int Compare(object x, object y)
    //        {
    //            HospitalMedication med1 = (HospitalMedication)x;
    //            HospitalMedication med2 = (HospitalMedication)y;
    //            return string.Compare(med1.Medication, med2.Medication);
    //        }
    //    }

    //    public class Program
    //    {
    //        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

    //        static void Main(string[] args)
    //        {
    //            // Example of CRUD operations
    //            HospitalMedicationService.Create(new HospitalMedication { HospitalID = 133, DoctorName = "Sanjay", Medication = "Dolo", Dosage = 600.5 });
    //            HospitalMedicationService.Create(new HospitalMedication { HospitalID = 124, DoctorName = "Dijol", Medication = "aerostol", Dosage = 550 });
    //            HospitalMedicationService.Create(new HospitalMedication { HospitalID = 123, DoctorName = "Sanjay", Medication = "Paracetamol", Dosage = 650 });
    //            HospitalMedicationService.Create(new HospitalMedication { HospitalID = 125, DoctorName = "Daisy", Medication = "Paracetamol", Dosage = 250 });
    //            HospitalMedicationService.Create(new HospitalMedication { HospitalID = 126, DoctorName = "Daisy", Medication = "Dolo", Dosage = 620 });



    //            log.Info("Initial records:");
    //            DisplayMedications();

    //            log.Info("Reading from database:");
    //            try
    //            {
    //                HospitalMedicationService.ReadFromDatabase();
    //            }
    //            catch (ServerException ex)
    //            {
    //                log.Error($"{ex.Message}");
    //            }
    //            DisplayMedications();

    //            log.Info("Updating a record:");
    //            HospitalMedicationService.Update(1, new HospitalMedication { HospitalID = 124, DoctorName = "Dijol", Medication = "aerostol", Dosage = 400 });
    //            DisplayMedications();

    //            log.Info("Deleting a record:");
    //            HospitalMedicationService.Delete(3);
    //            DisplayMedications();

    //            log.Info("Sorting records:");
    //            HospitalMedicationService.Sort();
    //            DisplayMedications();

    //            string doctorNameforMaxDosage = "Sanjay";
    //            HospitalMedication max = HospitalMedicationService.FindMax(doctorNameforMaxDosage);
    //            log.Info($"Max dosage for {doctorNameforMaxDosage} = {max}");

    //            HospitalMedication secondMin = HospitalMedicationService.FindSecondMin();
    //            log.Info($"Second minimum dosage medication = {secondMin}");
    //        }

    //        private static void DisplayMedications()
    //        {
    //            string output = "";
    //            foreach (HospitalMedication medication in HospitalMedicationService.GetMedications())
    //            {
    //                output += $"{medication}\n";
    //            }
    //            log.Info(output);
    //        }
    //    }
    //}

    //public class HospitalMedication
    //    {
    //        public int HospitalID { get; set; }

    //        public string DoctorName { get; set; }

    //        public string Medication { get; set; }

    //        public double Dosage { get; set; }

    //        public override string ToString()
    //        {
    //            return $"[{HospitalID},{DoctorName},{Medication},{Dosage}]";
    //        }
    //    }

    //    public class HospitalMedicationService
    //    {
    //        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4Assessment;Integrated Security=True;";
        //public static void Create(HospitalMedication medication)
        //        {
        //            hospitalMedications.Add(medication);

//        }

//        public static void ReadFromDatabase()
//        {
//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    string query = "SELECT HospitalID, DoctorName, Medication, Dosage FROM HospitalMedication";
//                    SqlCommand cmd = new SqlCommand(query, conn);
//                    conn.Open();
//                    SqlDataReader reader = cmd.ExecuteReader();
//                    hospitalMedications.Clear();
//                    while (reader.Read())
//                    {
//                        hospitalMedications.Add(new HospitalMedication
//                        {
//                            HospitalID = (int)reader["HospitalID"],
//                            DoctorName = reader["DoctorName"].ToString(),
//                            Medication = reader["Medication"].ToString(),
//                            Dosage = (double)reader["Dosage"]
//                        });
//                    }
//                }
//            }






