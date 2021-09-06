using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eShop.Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private IUserApplicationService _UserApplicationService;
        public AuthController(IUserApplicationService UserApplicationService)
        {
            _UserApplicationService = UserApplicationService;
        }

        [Route("registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [Route("registration")]
        [HttpPost]

        public IActionResult Registration(UserModel model)
        {
            
            var ResponseCore = _UserApplicationService.Registration(new UserDTO
            {
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                RepeatPasswordHash = model.RepeatPasswordHash,
                FirtsName = model.FirstName,
                LastName = model.LastName
            });
          
            ViewData["info"] = ResponseCore.Messages;

            return View();
        }

        [HttpGet]
        public IActionResult Activation()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Activation(Guid code)
        {

            return View();
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
