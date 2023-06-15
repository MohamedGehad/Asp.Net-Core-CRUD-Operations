using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisLogicLayer.interfaces
{
	public interface IGenericRepository<T>  where T : class
	{
		IEnumerable<T> GetAll();


		T Get(int id);

		void add(T item);

		void Update(T item);
		void delete(T item);
	}
}
