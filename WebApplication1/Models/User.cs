using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        [Required]
        public string userName { get; set; }

        [RegularExpression("^[0-9]*$")]
        public string PhoneNo { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email
        {
            get; set;
        }
    }
}