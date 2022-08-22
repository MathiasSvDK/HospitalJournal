using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorIdentityServerTest.Models
{
    public partial class Journal
    {
        public int Id { get; set; }
        public int? AssignedEmployee { get; set; }
        public int? AssignedPatient { get; set; }
        public string? Text { get; set; }
        public int? HospitalId { get; set; }
        public string? Date { get; set; }
        [NotMapped]
        public List<Attachment> Attachments { get; set; }
    }
}
