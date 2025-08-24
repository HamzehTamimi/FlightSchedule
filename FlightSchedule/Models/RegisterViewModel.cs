using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]

        public string ConfirmPassword { get; set; }
    }
}
