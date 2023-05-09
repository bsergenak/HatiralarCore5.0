using Microsoft.AspNetCore.Mvc;

namespace Hatiralar.WebUII.Controllers
{
    public class AuthhController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
