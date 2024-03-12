using Microsoft.AspNetCore.Mvc;
using Project.FrontEnd.Models;
using Project.Proxy;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private const string SessionId = "_customerid";
        private const string SessionName = "_name";
        private readonly ICustomer _customer;
        public LoginController(ICustomer customer)
        {
            _customer = customer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionId);
            HttpContext.Session.Remove(SessionName);
            return Redirect("/");
        }

        [HttpPost]
      [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(LoginViewModel request)
        {
            ViewBag.error = "";
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Bạn chưa nhập thông tin";
                return View();


            }
            var user = await _customer.Login(request);
            if (user.Status== false)
            {
                ViewBag.error = user.Message;
                return View();
            }

            HttpContext.Session.SetString(SessionId, user.Customer.Id.ToString());

            HttpContext.Session.SetString(SessionName, user.Customer.FullName.ToString());

            return Redirect("/customer");

        }
    }
}
