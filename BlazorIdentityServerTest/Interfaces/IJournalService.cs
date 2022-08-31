using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Interfaces;

public interface IJournalService
{
    JournalContext _journalContext { get; set; }

    ///<summary>
    /// Create a new journal
    ///<param name="journal">Journal to be created</param>
    /// <returns>The created journal</returns>
    /// </summary>
    Task<Journal> CreateJournal(Journal journal);

    ///<summary>
    /// Save the changes to the database
    /// </summary>
    Task SaveAsync();

    ///<summary>
    /// Create a request for chaning a journal that is not owned by the journal owner
    ///<param name="journal">The journal update</param>
    ///<param name="attachments">New attachments</param>
    ///<param name="editorid">The ID of the employee who is editing the journal</param>
    /// </summary>
    Task CreateRequest(Journal journal, List<Attachment> attachments, int editorId);

    ///<summary>
    /// Approve changes on a journal 
    ///<param name="approve">The journalapprove object that will be approved</param>
    /// </summary>
    Task ApproveChanges(JournalApprove approve);

    ///<summary>
    /// Deny chnges to the 
    ///<param name="journal">The journal update</param>
    ///<param name="attachments">New attachments</param>
    ///<param name="editorid">The ID of the employee who is editing the journal</param>
    /// </summary>
    void Denychanges(int approveId);

    JournalApprove GetJournalPending(int journalId);

    ///<summary>
    /// Check if a journal by id has a pending change
    /// <returns>true if there is a pending change. False if not</returns>
    /// </summary>
    bool HasPending(int journalId);

    ///<summary>
    /// Move a journal to a new hospital
    ///<param name="journalId">ID of the journal to be moved</param>
    ///<param name="hospitalID">The new hospital ID</param>
    /// </summary>
    void MoveJournal(int journalId, int hospitalId);

    ///<summary>
    /// Get a journal based on journal ID
    ///<param name="journalIDd">ID of the journal to get</param>
    /// </summary>
    Journal Get(int journalId);

    ///<summary>
    /// Get a list of journals by a users CPR number
    ///<param name="cpr">CPR number</param>
    /// </summary>
    List<Journal> GetByCPR(int cpr);
}