using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorIdentityServerTest.Models;

public class JournalLog
{
    public int Id { get; set; }
    public int JournalId { get; set; }
    public string Text { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    [NotMapped]
    public ApplicationUser Employee { get; set; }
}