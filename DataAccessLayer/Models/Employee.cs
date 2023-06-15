using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        public int Id { get; set; }


        [Required ]
        [MaxLength (50)]
        [MinLength(5)]
        public string Name { get; set; }

        public int? Age { get; set; }
        //[RegularExpression("^[0,9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,15}$",
        //    ErrorMessage = "Address Must be like 123-striet-city-countru")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime HairDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;



        public string imageName { get; set; }

        //navegtuion prop [one]
        public department department { get; set; }
    }
}
