using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;

namespace PrestionLayer.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Requird")]
        [MaxLength(50, ErrorMessage = "please input Max Length 50")]
        [MinLength(5, ErrorMessage = "please input Min Length 5")]
        public string Name { get; set; }
        [Range(22, 40)]

        public int? Age { get; set; }
        //[RegularExpression("^[0,9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,15}$",
        //    ErrorMessage = "Address Must be like 123-striet-city-countru")]
        public string Address { get; set; }

        public IFormFile Image{ get; set; }
		public string imageName { get; set; }

		public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public DateTime HairDate { get; set; }




        //navegtuion prop [one]
        public department department { get; set; }


    }
}
