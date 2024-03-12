using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;

namespace Project.FrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        private const string SessionId = "_customerid";
        private const string SessionName = "_name";
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        public async Task<IActionResult> Index()
        {
            string userId = HttpContext.Session.GetString(SessionId);
            string fullname= HttpContext.Session.GetString(SessionName);
            if (string.IsNullOrEmpty(userId))
            {
               return Redirect("/");
            }
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            int id = int.Parse(userId);
            var user = await _customer.GetById(id);
            return View(user);
        }
    }
}
