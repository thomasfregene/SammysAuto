using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Data
{
    public class SammysAutoApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        //public bool IsAdmin { get; set; }
    }

    public class SammysAutoApplicationRole : IdentityRole
    {
        public SammysAutoApplicationRole()
        {

        }
        public SammysAutoApplicationRole(string roleName)
        {
        }
    }
}
