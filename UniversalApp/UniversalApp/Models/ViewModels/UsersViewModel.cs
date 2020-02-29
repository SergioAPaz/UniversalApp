using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversalApp.Models;

namespace UniversalApp.Models.ViewModels
{
    public class UsersViewModel
    {
        public List<Role> Role { get; set; }
        public User User { get; set; }

    }
}