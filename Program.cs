using HospitalMonitoringSystem.Interfaces;
using HospitalMonitoringSystem.Models;
using HospitalMonitoringSystem.Repositories;
using System.ComponentModel.DataAnnotations;

namespace HospitalMonitoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            //Bu satır, generic bir repository sınıfını kullanarak, Doctor tipi için bir repository oluşturur.
            IRepository<Doctor> _doctorRepo = new Repository<Doctor>(context);
            IRepository<Medicine> _medicineRepo = new Repository<Medicine>(context);
            IRepository<Patient> _patientRepo = new Repository<Patient>(context);
            IRepository<Prescription> _prescriptionRepo = new Repository<Prescription>(context);
            IRepository<Visit> _visitRepo = new Repository<Visit>(context);

            while (true)
            {
                Console.WriteLine("Devam Etmek İçin Bir Tuşa Basınız");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Hastane Sistemine Hoşgeldiniz");
                Console.WriteLine("1-Hastaları Listele");
                Console.WriteLine("2-Ekleme");
                Console.WriteLine("3-Silme");
                Console.WriteLine("4-Güncelleme");
                Console.WriteLine("5-Çıkış yapınız");

                Console.Write("Seçim Yapınız :");
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        GetPatient(_patientRepo);
                        break;
                    case "2":
                        CreatePatient(_patientRepo);
                        break;
                    case "3":
                        DeletePatient(_patientRepo);
                        break;
                    case "4":
                        UpdatePatient(_patientRepo);
                        break;
                    case "5":
                        Console.WriteLine("Çıkış Yapılıyor.");
                        return;
                        
                    default:
                        Console.WriteLine("1-5 arasında bir tuşlama yapınız.");
                        break;
                }



            }

        }

        static void GetPatient(IRepository<Patient> _patientRepo)
        {
            var patients = _patientRepo.GetAll();
            foreach (var item in patients)
            {
                Console.WriteLine($"[{item.Id}] - {item.FullName}");
            }
        }

        static void CreatePatient(IRepository<Patient> _patientRepo)
        {
            Console.WriteLine("Hasta Adını ve Soyadını giriniz :");
            var isim = Console.ReadLine();
            Console.WriteLine("Doktor ıd giriniz :");
            int doktor = int.Parse(Console.ReadLine());

            var yenihasta = new Patient
            {
                FullName = isim,
                DoctorId=doktor
            };

            _patientRepo.Add(yenihasta);
            _patientRepo.Save();
            Console.WriteLine("Hasta Eklendi.");
        }

        static void DeletePatient(IRepository<Patient> _patientRepo)
        {
            GetPatient(_patientRepo);
            Console.WriteLine("Silinecek Hastayı Seçiniz");
            Console.Write("Id giriniz :");
            int hasta = int.Parse(Console.ReadLine());
            _patientRepo.Remove(hasta);
            _patientRepo.Save();
            Console.WriteLine("Hasta başarılı bir şekilde silindi");

        }

        static void UpdatePatient(IRepository<Patient> _patientRepo)
        {
            GetPatient(_patientRepo);
            Console.Write("Silmek istediğiniz hasta Id giriniz : ");
            int ıd = int.Parse(Console.ReadLine());
            var hasta1 = _patientRepo.GetById(ıd);

            Console.WriteLine("Yeni hasta adını giriniz"); ;
            string guncelHasta = Console.ReadLine();
            hasta1.FullName = guncelHasta;
            _patientRepo.Save();
            Console.WriteLine("Hasta başarılı bir şekilde güncellendi");
        }


    }
}
