using HospitalMonitoringSystem.Interfaces;
using HospitalMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMonitoringSystem.Repositories
{

    

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;  
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();


        public T GetById(int id) => _context.Set<T>().Find(id);
        

       

        public void Remove(int id)
        {
            _context.Remove(GetById(id));
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public void Update(T Entitiy)
        {
            _context.Update(Entitiy);
        }

        
    }
}
