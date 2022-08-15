using System;
using System.Collections.Generic;

namespace BlazorIdentityServerTest.Models
{
    public partial class JournalApprove
    {
        public int Id { get; set; }
        public int? PageId { get; set; }
        public int? EditorId { get; set; }
        public int? OwnerId { get; set; }
    }
}
