namespace HospitalMonitoringSystem.Models
{
    public class Patient : BaseEntity
    {
        public string FullName { get; set; }

        public DateTime BirtDate { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        //her hastanın birden fazla ziyaretcisi vardır.
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();

        public override string ToString()
        {
            return $"Hasta : {FullName} Doğum Tarihi : {BirtDate.ToShortDateString()}";
        }

    }

}
