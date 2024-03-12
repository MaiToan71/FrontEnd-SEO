using System.ComponentModel.DataAnnotations;

namespace Project.Proxy.ViewModels
{
    public class LoginViewModel
    {

        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
