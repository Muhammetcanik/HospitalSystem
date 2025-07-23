using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMonitoringSystem.Models
{
    public class Doctor : BaseEntity
    {
        public string FullName { get; set; }

        public string Specialization { get; set; }

        //bir doktorun birden fazla hastası olabilir.
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public override string ToString()
        {
            return $"İsim : {FullName} Uzmanlık : {Specialization}";
        }

    }

}
