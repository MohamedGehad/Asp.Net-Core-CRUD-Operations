using System;
using System.ComponentModel.DataAnnotations;

namespace PrestionLayer.ViewModels
{
	public class RegesterViewModel
	{

        public String Fname  { get; set; }
        public String Lname  { get; set; }
        [Required(ErrorMessage ="Email is Requierd")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)] 
        public string Password { get; set; }

		[Required(ErrorMessage ="confirm password is req")]
		[Compare("Password" , ErrorMessage ="comfirm Password not match") ]
		[DataType(DataType.Password)]
        public String ConfirmPassword{ get; set; }

        public bool	 IsAgree{ get; set; }

    }
}
