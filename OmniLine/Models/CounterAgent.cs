using System.ComponentModel.DataAnnotations;

namespace OmniLine.Models
{
    public class CounterAgent
    {
        [Key]
        public int CounterAgentId { get; set; }
        public string Name { get; set; }
        public string? DateCreate { get; set; }
        public string DateEdit { get; set; } = " ";
        public ICollection<Contact>? Contacts { get; set; }

    }
}
