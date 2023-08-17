using eshop.Application.Services;
using eshop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? gidilecekSayfa)
        {
            if(ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),                        
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Email, user.Email),

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    
                    return Redirect("/"); 
                   

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre yanlış.");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
