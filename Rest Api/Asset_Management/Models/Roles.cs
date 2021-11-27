using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Login = new HashSet<Login>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
