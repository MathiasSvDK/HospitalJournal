using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorIdentityServerTest.Models
{
    public partial class Hospital
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Beds { get; set; }
        [NotMapped]
        public int EmployeeCount {get;set;}
    }
}
