using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlazorIdentityServerTest.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilnr { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public int HospitalId { get; set; }
        public string Email { get; set; }
    }
}