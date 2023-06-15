using BussnisLogicLayer.interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.Repos
{
	public class DepartmentRepository : GenericRepository<department>, IDepartmentRepository
	{
        public DepartmentRepository(MvcDbContext dbContext):base(dbContext)
        {
              
        }

    }
}
