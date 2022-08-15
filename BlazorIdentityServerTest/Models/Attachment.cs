using System;
using System.Collections.Generic;

namespace BlazorIdentityServerTest.Models
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? BlockId { get; set; }
    }
}
