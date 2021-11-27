using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class UserRegistration
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int LoginId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Login Login { get; set; }
    }
}
