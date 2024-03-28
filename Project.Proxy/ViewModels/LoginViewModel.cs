using System.ComponentModel.DataAnnotations;

namespace Project.Proxy.ViewModels
{
    public class LoginViewModel
    {

        public required string Username { get; set; }

        public required string Password { get; set; }
    }

    public class RegisterViewModel
    {

       public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Cmnd { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfCmnd { get; set; }
    }
}
