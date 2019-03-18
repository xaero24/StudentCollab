using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentCollab.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int rank { get; set; }
        public string institution { get; set; }
        public int? year { get; set; }

        public User()
        {
       
        }

        public User(User usr)
        {
            this.UserName = usr.UserName;
            this.Password = usr.Password;
            this.rank = usr.rank;
            this.institution = usr.institution;
            this.year = usr.year;
        }
    }
}