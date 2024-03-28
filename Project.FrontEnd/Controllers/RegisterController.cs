using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ICustomer _customer;
        public RegisterController(ICustomer customer)
        {
            _customer = customer;
        }
       // [Route("dang-ky")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel request)
        {
            ViewBag.error = "";
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Bạn chưa nhập thông tin";
                return View();


            }
            var obj = new RegisterViewModel
            {
                Address = request.Address,
                Cmnd = request.Cmnd,
                DateOfBirth = request.DateOfBirth,
                DateOfCmnd = request.DateOfCmnd,
                FullName = request.FullName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
            };
           await _customer.Register(obj);
            return Redirect("/login");

        }
    }
}
