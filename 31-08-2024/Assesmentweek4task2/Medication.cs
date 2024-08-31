using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
    public class Medication
    {
        public int HospitalID { get; set; }
        public string DoctorName { get; set; }
        public string Name { get; set; }
        public double Dosage { get; set; }

        public Medication(int hospitalID, string doctorName, string name, double dosage)
        {
            HospitalID = hospitalID;
            DoctorName = doctorName;
            Name = name;
            Dosage = dosage;
        }

        public override string ToString()
        {
            return $"[HospitalID={HospitalID}, DoctorName={DoctorName}, Name={Name}, Dosage={Dosage}]";
        }
    }
}