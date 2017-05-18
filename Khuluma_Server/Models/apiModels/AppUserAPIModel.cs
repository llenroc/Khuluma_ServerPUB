using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.apiModels
{
    public class AppUserAPIModel
    {

        public int ID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        public string HomeAddress { get; set; }

        public string Notes { get; set; }

        public string ParticipantId { get; set; }

        public int LocationId { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

    }
}