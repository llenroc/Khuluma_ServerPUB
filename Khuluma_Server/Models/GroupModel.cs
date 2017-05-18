using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class GroupModel
    {
        [Key]
        [Display(Name = "Number")]
        public int ID { get; set; }

        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "Is Group Active?")]
        public bool Active { get; set; }

        [Display(Name = "Number of Members")]
        public int NumberofMembers { get; set; }

        public virtual ICollection<AppUserModel> AppUsers { get; set; }

        public int GetNumberofMembers()
        {
            return NumberofMembers;
        }
    }
}