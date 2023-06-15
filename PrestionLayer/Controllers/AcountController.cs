using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrestionLayer.Helper;
using PrestionLayer.ViewModels;
using System.Globalization;
using System.Threading.Tasks;

namespace PrestionLayer.Controllers
{
	public class AcountController : Controller
	{
		private readonly UserManager<AppUsers> _userManager;
		private readonly SignInManager<AppUsers> _signInManager;

		public AcountController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		#region Regester

		//Acount/Regester
		public IActionResult Rsgister()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Rsgister(RegesterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new AppUsers()
				{
					Fname = model.Fname,
					Lname = model.Lname,
					UserName = model.Email.Split('@')[0],
					Email = model.Email,
					IsAgree = model.IsAgree

				};
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
					return RedirectToAction(nameof(Login));

				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description); 


			}
			return View(model);
		 }

		#endregion

		#region Login

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewLogin model)
		{

			if (ModelState.IsValid)
			{

				var user  = await _userManager.FindByEmailAsync(model.Email);
				if(user is not null)
				{

					var flag = await _userManager.CheckPasswordAsync(user, model.Password);
						if (flag)
						{
							await _signInManager.PasswordSignInAsync(user , model.Password , model.RemmeberMe,false);
							return RedirectToAction("Index", "Home");
						}
						ModelState.AddModelError(string.Empty, "invalid Password");
					
				}
				ModelState.AddModelError(string.Empty, "email is not exited");
			}
			return View(model);
		}



		#endregion

		#region SiginOut
		public new async Task<IActionResult> SiginOut()
		{
			await _signInManager.SignOutAsync(); 
			return RedirectToAction(nameof(Login));
		}
		#endregion


		#region ForgetPassword

		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
		{
			if(ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);
				if(user is not null)
				{
					var token= _userManager.GeneratePasswordResetTokenAsync(user);
					var passwordRestLink = Url.Action("RestPassword", "Acount", 
						new { Email = user.Email, token }, Request.Scheme );
					//acount/restpassword/email
					var Email = new Email
					{
						Subject = "rest Password",
						To = user.Email,
						Body = passwordRestLink
					};
					EmailSettings.SendEmail(Email);
					return RedirectToAction(nameof(chekyourInbox));

				}
				ModelState.AddModelError(string.Empty, "EMIAL IS NOT EXIST");
			}
			return View(model);
		}


		public IActionResult chekyourInbox()
		{
			return View();
		}
		#endregion
	}
}
