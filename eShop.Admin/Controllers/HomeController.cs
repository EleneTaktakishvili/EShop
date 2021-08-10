using eShop.Admin.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace eShop.Admin.Controllers
{
    public class HomeController : Controller
    {
      
        public HomeController()
        {
           
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
