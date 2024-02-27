using OmniLine.Models;

namespace OmniLine.ViewModel
{
    public class CreateAgentVM
    {

        public CounterAgent Agent { get; set; }

        public CreateAgentVM()
        {
            Agent = new CounterAgent();
            Agent.DateCreate = DateTime.Now.ToString();
        }

        public CreateAgentVM(CreateAgentVM vmModel)
        {
            Agent.DateEdit = DateTime.Now.ToString();
        }
    }
}
