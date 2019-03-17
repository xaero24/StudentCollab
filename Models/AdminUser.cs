using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCollab.Models
{
    [NotMapped]
    public class AdminUser : User
    {
        //Copy Ctor
        public AdminUser(User usr)
        {
            this.UserName = usr.UserName;
            this.Password = usr.Password;
            this.rank = usr.rank;
            this.institution = usr.institution;
            this.year = usr.year;
        }
    }
}