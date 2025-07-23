namespace HospitalMonitoringSystem.Models
{
    public class PrescriptionMedicine 
    {
        public int  PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"İlaç: {Medicine?.Name} - Adet: {Quantity}";
        }
    }

}
