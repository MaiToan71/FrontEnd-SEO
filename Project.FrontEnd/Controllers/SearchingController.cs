using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;

namespace Project.FrontEnd.Controllers
{
    public class SearchingController : Controller
    {
        private readonly ICustomer _ICustomer;
        public SearchingController(ICustomer ICustomer)
        {
            _ICustomer = ICustomer;
        }

        [Route("tra-cuu-ho-so")]
        public async Task<IActionResult> Index(string cmnd)
        {
            string searchCmnd = "";
            if (!string.IsNullOrEmpty(cmnd))
            {
                searchCmnd = cmnd;
            }
            var data = await _ICustomer.GetCustomerInCalenar(searchCmnd);
            return View(data);
        }
    }
}
