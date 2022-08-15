using System;
using System.Collections.Generic;

namespace BlazorIdentityServerTest.Models
{
    public partial class Journal
    {
        public int Id { get; set; }
        public string? Attachments { get; set; }
        public string? AssignedEmp { get; set; }
        public string? AssignedPat { get; set; }
        public int? Pages { get; set; }
        public int? HospitalId { get; set; }
    }
}
