using Microsoft.AspNetCore.Mvc;

namespace OmniLine.Controllers
{
    public class ContactController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
