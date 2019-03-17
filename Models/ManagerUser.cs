using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCollab.Models
{
    [NotMapped]
    public class ManagerUser : User
    {
        protected int JuristictionID { get; set; }

        //Copy Ctor
        public ManagerUser(User usr)
        {
            this.UserName = usr.UserName;
            this.Password = usr.Password;
            this.rank = usr.rank;
            this.institution = usr.institution;
            this.year = usr.year;
        }
    }
}