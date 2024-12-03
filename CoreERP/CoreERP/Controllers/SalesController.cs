using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
