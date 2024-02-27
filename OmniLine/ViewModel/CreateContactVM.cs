using OmniLine.Models;


namespace OmniLine.ViewModel
{
    public class CreateContactVM
    {
        public Contact Contact { get; set; }
        public IEnumerable<CounterAgent>? Agents { get; set; }
    }
}
