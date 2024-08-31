using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4AssessmentApp;

namespace Week4AssessmentApp
{
    public class MedicationDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4Assessment;Integrated Security=True;";

        public void Create(Medication medication)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Medication (HospitalID, DoctorName, Name, Dosage) VALUES (@HospitalID, @DoctorName, @Name, @Dosage)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HospitalID", medication.HospitalID);
                cmd.Parameters.AddWithValue("@DoctorName", medication.DoctorName);
                cmd.Parameters.AddWithValue("@Name", medication.Name);
                cmd.Parameters.AddWithValue("@Dosage", medication.Dosage);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Medication Read(int hospitalID)
        {
            Medication medication = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT HospitalID, DoctorName, Name, Dosage FROM Medication WHERE HospitalID = @HospitalID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HospitalID", hospitalID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    medication = new Medication(
                        (int)reader["HospitalID"],
                        reader["DoctorName"].ToString(),
                        reader["Name"].ToString(),
                        (double)reader["Dosage"]
                    );
                }
            }
            return medication;
        }

        public void Update(Medication medication)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Medication SET DoctorName = @DoctorName, Name = @Name, Dosage = @Dosage WHERE HospitalID = @HospitalID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HospitalID", medication.HospitalID);
                cmd.Parameters.AddWithValue("@DoctorName", medication.DoctorName);
                cmd.Parameters.AddWithValue("@Name", medication.Name);
                cmd.Parameters.AddWithValue("@Dosage", medication.Dosage);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int hospitalID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Medication WHERE HospitalID = @HospitalID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HospitalID", hospitalID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Medication> ListAll()
        {
            List<Medication> medications = new List<Medication>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT HospitalID, DoctorName, Name, Dosage FROM Medication";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medication medication = new Medication(
                        (int)reader["HospitalID"],
                        reader["DoctorName"].ToString(),
                        reader["Name"].ToString(),
                        (double)reader["Dosage"]
                    );
                    medications.Add(medication);
                }
            }
            return medications;
        }
    }

}