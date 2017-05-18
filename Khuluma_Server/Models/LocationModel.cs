using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class LocationModel
    {
        [Key]
        [Display(Name = "Number")]
        public int ID { get; set; }

        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }

        public string Province { get; set; }
    }
}