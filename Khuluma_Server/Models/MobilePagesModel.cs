using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khuluma_Server.Models
{
    public class MobilePagesModel
    {
        [Key]
        public int PageId { get; set; }

        [Display(Name = "Title")]
        public string PageTitle { get; set; }

        [Display(Name = "Content")]
        [AllowHtml]
        public string PageHTMLContent { get; set; }
    }
}