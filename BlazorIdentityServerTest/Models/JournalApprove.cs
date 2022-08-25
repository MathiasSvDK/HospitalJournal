using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorIdentityServerTest.Models
{
    public partial class JournalApprove
    {
        [Key]
        public int Id { get; set; }
        public int? JournalId { get; set; }
        public int? EditorId { get; set; }
        public int? OwnerId { get; set; }
        public string NewAttachments { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string? Note { get; set; }
        public int Approved { get; set; }
        [NotMapped]
        public List<Attachment> NewAttachmentsList { get; set; }
    }
}
