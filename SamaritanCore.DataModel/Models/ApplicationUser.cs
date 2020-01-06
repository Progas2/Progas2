using System;
using Microsoft.AspNetCore.Identity;

namespace SamaritanCore.DataModel.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ApplicationUser()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
