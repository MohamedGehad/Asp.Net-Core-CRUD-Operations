using BussnisLogicLayer.interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MvcDbContext _dbcontext;

        public GenericRepository(MvcDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void delete(T item)
        =>    _dbcontext.Set<T>().Remove(item);

        public T Get(int id)
        {
            return _dbcontext.Set<T>().Find(id);
            //_dbcontext.Employees.Where(D => D.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {

            if (typeof(T) == typeof(Employee))
                return (IEnumerable<T>)_dbcontext.Employees.Include(E => E.department).ToList();
            else
                return _dbcontext.Set<T>().ToList();
        }


        public void Update(T item)
        =>   _dbcontext.Set<T>().Update(item);

        public void add(T item)
        => _dbcontext.Set<T>().Add(item);
    }
}
