using HospitalMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMonitoringSystem.Interfaces
{
   public interface IDoctorServices : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetBySpecialization(string specialization);
        //IGenericRepo<Doctor>'dan kalıtım alarak Add, Delete, GetAll, GetById, Update gibi CRUD işlemler otomatik geliyor.
        //Ben sadece ekstra metodunu (örneğin GetBySpecialization) ekledim.

    }
}
