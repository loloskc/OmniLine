using Microsoft.AspNetCore.Mvc;
using OmniLine.Interfaces;
using OmniLine.Models;
using System.Diagnostics;

namespace OmniLine.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactRepository.GetAll();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
