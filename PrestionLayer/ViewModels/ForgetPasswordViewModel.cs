using System.ComponentModel.DataAnnotations;

namespace PrestionLayer.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is Requierd")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

    }
}
