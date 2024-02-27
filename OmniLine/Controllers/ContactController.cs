using Microsoft.AspNetCore.Mvc;
using OmniLine.Interfaces;
using OmniLine.Models;
using OmniLine.ViewModel;
using System.Diagnostics;

namespace OmniLine.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICounterAgentRepository _counterAgentRepository;

        public ContactController(IContactRepository contactRepository,ICounterAgentRepository counterAgentRepository)
        {
            _contactRepository = contactRepository;
            _counterAgentRepository = counterAgentRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactRepository.GetAll();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateContactVM viewModel = new CreateContactVM();
            viewModel.Agents = await _counterAgentRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactVM viewModel)
        {
            var contact = viewModel.Contact;

              if (ModelState.IsValid)
            {
                contact.CounterAgent = await _counterAgentRepository.GetById(contact.CounterAgentId);
                _contactRepository.Add(contact);
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.Agents = await _counterAgentRepository.GetAll();
               return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contact =  await _contactRepository.GetById(id);
            if (contact != null)
            {
                _contactRepository.Delete(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
