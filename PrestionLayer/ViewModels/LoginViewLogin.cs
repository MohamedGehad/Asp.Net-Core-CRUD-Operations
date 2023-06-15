using System.ComponentModel.DataAnnotations;
using System;

namespace PrestionLayer.ViewModels
{
	public class LoginViewLogin
	{
		
		[Required(ErrorMessage = "Email is Requierd")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "confirm password is req")]
		
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RemmeberMe { get; set; }
	}
}
