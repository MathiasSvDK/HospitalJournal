using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Services;

public class LogsService
{
    
    public JournalContext _logContext { get; set; }
    public LogsService(JournalContext _lContext)
    {
        _logContext = _lContext;
    }

    public List<JournalLog> Get(int journalId)
    {
        return _logContext.JournalLogs.Where(x => x.JournalId == journalId).ToList();
    }

    public void Insert(int journalId, string employee, string text)
    {
        _logContext.JournalLogs.Add(new JournalLog()
        {
            JournalId = journalId,
            Text = text,
            EmployeeId = Convert.ToInt32(employee),
            Date = DateTime.Now
        });
        _logContext.SaveChanges();
    }

}