using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class department
	{
        public int Id { get; set; }
		[Required(ErrorMessage ="Code is Required")]
		public string Code { get; set; }
		[Required(ErrorMessage ="Name is Required")]
		[MaxLength(50)]
		public string Name { get; set; }
		public DateTime DateOfCreation { get; set; } = DateTime.Now;


		//[ForeignKey ("department")]
        public  int? Deprtmetnid { get; set; } // forgin key => allow null 
        // navition prop [many]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
