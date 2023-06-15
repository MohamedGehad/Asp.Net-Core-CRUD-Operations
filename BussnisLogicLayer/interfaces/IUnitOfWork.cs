using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeReposatory EmployeeReposatory { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        int complete();
    }
}
