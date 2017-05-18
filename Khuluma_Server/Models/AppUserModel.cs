using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class AppUserModel
    {
        [Key]
        [Display(Name = "Number")]
        public int ID { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Participant ID")]
        public string ParticipantId { get; set; }

        public int? LocationId { get; set; }

        public virtual LocationModel Location { get; set; }

        public int? GroupId { get; set; }

        public virtual GroupModel Group { get; set; }
    }
}