using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Admin.Controllers
{
    
    [Route("auth")]
    public class AuthController : Controller
    {
        private IUserApplicationService _UserApplicationService;

        public AuthController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;

        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginModel Login)
        {
            var ResponseCore = _UserApplicationService.Login(new LoginDTO
            {
                Email = Login.Email,
                PasswordHash = Login.PasswordHash
            });

            if (ResponseCore.Messages.Count == 0)
            {
                HttpContext.Session.SetString("SessionID", ResponseCore.SessionID.ToString());
                HttpContext.Session.SetString("UserName", Login.Email);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(ResponseCore.Messages);
            }         
        }

        [Route("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("SessionID");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Clear();        

            return RedirectToAction("Login", "Auth");
        }
    }
}
