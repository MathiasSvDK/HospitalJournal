using BlazorIdentityServerTest.Models;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services;

public class LogsService : ILogsService
{
    
    public JournalContext _logContext { get; set; }
    public LogsService(JournalContext _lContext)
    {
        _logContext = _lContext;
    }

    ///<summary>
    /// Get logs from a journal by journalId
    ///<param name="journal">ID of the journal</param>
    /// <returns>Returns a list of journalLog</returns>
    /// </summary>
    public List<JournalLog> Get(int journalId)
    {
        return _logContext.JournalLogs.Where(x => x.JournalId == journalId).ToList();
    }

    ///<summary>
    /// Insert a new log on a journal
    ///<param name="journalId">ID of the journal to insert it to</param>
    ///<param name="employee">the employeees ID</param>
    ///<param name="text">Text to show</param>
    /// </summary>
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