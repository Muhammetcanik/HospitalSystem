namespace HospitalMonitoringSystem.Models
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

        public override string ToString()
        {
            return $"İlaç: {Name} - Açıklama: {Description}";
        }

    }

}
