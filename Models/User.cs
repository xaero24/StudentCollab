using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentCollab.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}