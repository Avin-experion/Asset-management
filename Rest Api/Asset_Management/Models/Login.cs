using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class Login
    {
        public Login()
        {
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }

        public virtual Roles UserTypeNavigation { get; set; }
        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
