using System.ComponentModel.DataAnnotations;

namespace WebApp1.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        //[DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}
