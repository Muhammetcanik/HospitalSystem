using HospitalMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMonitoringSystem.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        void Add(T entity);
        void Remove(int id);
        void Update(T Entitiy);

        bool Save();
    }
}
