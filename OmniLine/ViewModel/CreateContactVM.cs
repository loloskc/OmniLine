using OmniLine.Models;


namespace OmniLine.ViewModel
{
    public class CreateContactVM
    {
        public Contact? Contact { get; set; }
        public IEnumerable<CounterAgent> Agents { get; set; }

        public CreateContactVM()
        {
            Contact.DateCreate = DateTime.Now.ToString();
        }
        public CreateContactVM(CreateContactVM vmodel)
        {
            Contact.DateEdit = DateTime.Now.ToString();
        }
    }
}
