using DataAccessLayer.Models;
using System.Net;
using System.Net.Mail;

namespace PrestionLayer.Helper
{
	public class EmailSettings
	{
		public static void SendEmail(Email email) 
		{
			var Clint = new SmtpClient("smtp.gmail.com", 587);
			Clint.EnableSsl = true;
			Clint.Credentials = new NetworkCredential("mohgehad13@gmail.com", "mabyeitnjbbbfwbu\r\n");
			Clint.Send("mohgehad13@gmail.com", email.To, email.Subject, email.Body);
		
		}
	}
}
