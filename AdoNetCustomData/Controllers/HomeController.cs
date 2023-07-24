using Microsoft.AspNetCore.Mvc;

namespace AdoNetCustomData.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        { 
            return View();
        } 
    }
}
