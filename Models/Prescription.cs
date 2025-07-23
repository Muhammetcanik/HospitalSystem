namespace HospitalMonitoringSystem.Models
{
    public class Prescription : BaseEntity
    {
        public string Diagnosis { get; set; }

        public int VisitId { get; set; }

        public Visit Visit { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

        public override string ToString()
        {
            return $"Reçete - Teşhis: {Diagnosis}";
        }

    }

}
