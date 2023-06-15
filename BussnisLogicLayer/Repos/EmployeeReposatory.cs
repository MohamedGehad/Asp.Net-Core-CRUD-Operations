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
	public class EmployeeReposatory : GenericRepository<Employee>, IEmployeeReposatory
	{
		private readonly MvcDbContext _dbContext;

		public EmployeeReposatory(MvcDbContext dbContext):base(dbContext)
        {
			_dbContext = dbContext;
		}


		public IQueryable<Employee> GetEmployeesnyaddress(string address)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Employee> SearchEmployeeByName(string name)
		=> _dbContext.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower()));
	}
}
