using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class FlaggedContentModel
    {
        public int ID { get; set; }

        [Display(Name = "Keyword / Phrase")]
        public string ContentText { get; set; }
    }
}