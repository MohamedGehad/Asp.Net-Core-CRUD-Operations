using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.interfaces
{
    public interface IEmployeeReposatory : IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesnyaddress(string address);
        IQueryable<Employee> SearchEmployeeByName(string name);
    }
}
