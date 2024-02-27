using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniLine.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? DateCreate { get; set; }
        public string DateEdit { get; set; } = " ";
        public string FIO { get; set; }
        public string Email { get; set; }
        [ForeignKey("CounterAgent")]
        public int CounterAgentId { get; set; }
        
        public CounterAgent? CounterAgent { get; set; }
    }
}

