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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var counterAgents = await _counterAgentRepository.GetById(id);
            if(counterAgents != null)
            {
                _counterAgentRepository.Delete(counterAgents);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var agent = await _counterAgentRepository.GetById(id);
            if(agent == null) return View("Error");
            var vModel = new CreateAgentVM()
            {
                Agent = agent
            };
            return View(vModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateAgentVM vModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit agent");
                return View("Edit",vModel);
            }
            var agent = vModel.Agent;
            agent.CounterAgentId = id;
            agent.DateEdit = DateTime.Now.ToString();
            _counterAgentRepository.Update(agent);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Detail(int id)
        {
            var agent = await _counterAgentRepository.GetByIdContact(id);
            return View(agent);   
        }
    }
}
