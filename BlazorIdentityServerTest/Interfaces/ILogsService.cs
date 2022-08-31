using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Interfaces;

public interface ILogsService
{
    JournalContext _logContext { get; set; }

    ///<summary>
    /// Get logs from a journal by journalId
    ///<param name="journal">ID of the journal</param>
    /// <returns>Returns a list of journalLog</returns>
    /// </summary>
    List<JournalLog> Get(int journalId);

    ///<summary>
    /// Insert a new log on a journal
    ///<param name="journalId">ID of the journal to insert it to</param>
    ///<param name="employee">the employeees ID</param>
    ///<param name="text">Text to show</param>
    /// </summary>
    void Insert(int journalId, string employee, string text);
}