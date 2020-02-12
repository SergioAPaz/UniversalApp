using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversalApp.Models.DBModels
{
    public class CustomUsersModel
    {
        public int id { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

        public virtual Role Role1 { get; set; }
    }
}