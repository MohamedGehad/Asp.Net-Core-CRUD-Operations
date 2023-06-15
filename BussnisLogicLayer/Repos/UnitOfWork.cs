using BussnisLogicLayer.interfaces;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcDbContext _dbContext;

        public IEmployeeReposatory EmployeeReposatory { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitOfWork(MvcDbContext dbContext)
        {
            EmployeeReposatory = new EmployeeReposatory(dbContext);

            DepartmentRepository = new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

        int IUnitOfWork.complete()
        => _dbContext.SaveChanges();

        public void Dispose()
        => _dbContext.Dispose(); 

    }   
}
