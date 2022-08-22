using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorIdentityServerTest.Models
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Uri { get; set; }
        public string? Filename { get; set; }
        public int? JournalId { get; set; }
        [NotMapped]
        public bool Delete { get; set; }
    }
}
