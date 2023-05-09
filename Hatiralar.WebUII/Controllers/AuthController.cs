using Hatiralar.Businees.Abstract;
using Hatiralar.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hatiralar.WebUII.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet] //Sadeece Görüntüyü Vericek, Post isteğini, AJAX ile Apiye göndereceğiz.
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet] //Sadeece Görüntüyü Vericek, Post isteğini AJAX ile Apiye göndereceğiz.
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _authService.UserRegister(registerDto);
        //        return RedirectToAction("/Auth/Login");
        //    }
        //    ModelState.AddModelError("", "Üyelik işlemi başarısız.");
        //    return View(registerDto);
        //}



        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _authService.Login(loginDto);
        //        return RedirectToAction("yönlendirilecek sayfa");
        //    }
        //    ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
        //    return View(loginDto);
        //}
    }
}
