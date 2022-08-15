using System;
using System.Collections.Generic;

namespace BlazorIdentityServerTest.Models
{
    public partial class Hospital
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Beds { get; set; }
    }
}
