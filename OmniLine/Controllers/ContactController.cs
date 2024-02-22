using Microsoft.AspNetCore.Mvc;
using OmniLine.Interfaces;
using OmniLine.Models;

namespace OmniLine.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
