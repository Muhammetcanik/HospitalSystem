namespace HospitalMonitoringSystem.Models
{
    public class Visit : BaseEntity
    {
        public DateTime VisitDate { get; set; }

        public string Notes { get; set; }

        //ziyaretcinin bir tane hastası vardır.

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Prescription Prescription { get; set; }

        public override string ToString()
        {
            return $"Ziyaret: {VisitDate.ToShortDateString()} - Notlar: {Notes}";
        }


    }

}
