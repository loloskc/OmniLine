using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniLine.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }
        public string DateCreate { get; set; }
        public string DateEdit { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        [ForeignKey("CounterAgent")]
        public long? CounterAgentId { get; set; }
        public int? CounterAgent { get; set; }
    }
}

