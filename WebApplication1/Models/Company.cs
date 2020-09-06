using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Company
    {
        [Required]
        public string name { get; set; }
        public string city { get; set; }
    }
}