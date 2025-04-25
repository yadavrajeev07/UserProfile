using Microsoft.AspNetCore.Mvc;

namespace userprofileapp.Controllers
{
    public class HomeController : Controller
    {
       
        // Action to show a "Contact" page
        public IActionResult Contact()
        {
            return View();
        }

        // Error page action
        public IActionResult Error()
        {
            return View();
        }
    }
}
