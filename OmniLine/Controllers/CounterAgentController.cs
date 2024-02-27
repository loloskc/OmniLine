using Microsoft.AspNetCore.Mvc;
using OmniLine.Interfaces;
using OmniLine.Models;
using OmniLine.ViewModel;


namespace OmniLine.Controllers
{
    public class CounterAgentController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICounterAgentRepository _counterAgentRepository;

        public CounterAgentController(IContactRepository contactRepository,ICounterAgentRepository counterAgentRepository)
        {
            _contactRepository = contactRepository;
            _counterAgentRepository = counterAgentRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CounterAgent> counterAgents = await _counterAgentRepository.GetAll();
            return View(counterAgents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAgentVM vmModel)
        {
            var agent = vmModel.Agent;

            if(ModelState.IsValid)
            {
                _counterAgentRepository.Add(agent);
                return RedirectToAction("Index");
            }
            else return View(vmModel);
        }
    }
}
