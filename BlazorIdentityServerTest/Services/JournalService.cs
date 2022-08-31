using BlazorIdentityServerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services
{
    public class JournalService : IJournalService
    {
        public JournalContext _journalContext { get; set; }
        public JournalService(JournalContext _jContext)
        {
            _journalContext = _jContext;
        }

        
        ///<summary>
        /// Create a new journal
        ///<param name="journal">Journal to be created</param>
        /// <returns>The created journal</returns>
        /// </summary>
        public async Task<Journal> CreateJournal(Journal journal) {
            await _journalContext.Journals.AddAsync(journal);
            return journal;
        }

        ///<summary>
        /// Save the changes to the database
        /// </summary>
        public async Task SaveAsync()
        {
            await _journalContext.SaveChangesAsync();
        }



        ///<summary>
        /// Create a request for chaning a journal that is not owned by the journal owner
        ///<param name="journal">The journal update</param>
        ///<param name="attachments">New attachments</param>
        ///<param name="editorid">The ID of the employee who is editing the journal</param>
        /// </summary>
        public async Task CreateRequest(Journal journal, List<Attachment> attachments, int editorId)
        {
            JournalApprove approve = new JournalApprove();
            approve.JournalId = journal.Id;
            approve.EditorId = editorId;
            approve.OwnerId = journal.AssignedEmployee;
            approve.NewAttachments = string.Join(",", attachments.Select(x => x.Id).ToList());
            approve.Text = journal.Text;
            approve.Note = journal.Note;

            _journalContext.JournalApproves.Add(approve);
        }


        ///<summary>
        /// Approve changes on a journal 
        ///<param name="approve">The journalapprove object that will be approved</param>
        /// </summary>
        public async Task ApproveChanges(JournalApprove approve)
        {
            //Get the journal and update the values
            Journal journal = _journalContext.Journals.Where(x => x.Id == approve.JournalId).First();
            journal.Text = approve.Text;
            //Get the attachments that is assigned to the journal and attach them to the journal
            List<Attachment> attachments = _journalContext.Attachments.Where(a => approve.NewAttachmentsList.Select(x => x.Id).ToList().Contains(a.Id)).ToList();
            foreach (Attachment att in attachments)
            {
                att.JournalId = journal.Id;
            }
            //Approve the approved
            approve.Approved = 1;
        }

        
        ///<summary>
        /// Deny chnges to the 
        ///<param name="journal">The journal update</param>
        ///<param name="attachments">New attachments</param>
        ///<param name="editorid">The ID of the employee who is editing the journal</param>
        /// </summary>
        public void Denychanges(int approveId)
        {
            _journalContext.JournalApproves.Where(x => x.Id == approveId).FirstOrDefault().Approved = 2;
        }
        
        

        public JournalApprove GetJournalPending(int journalId)
        {
            return _journalContext.JournalApproves.Where(x => x.JournalId == journalId && x.Approved == 0).FirstOrDefault();
        }

        ///<summary>
        /// Check if a journal by id has a pending change
        /// <returns>true if there is a pending change. False if not</returns>
        /// </summary>
        public bool HasPending(int journalId)
        {
            return _journalContext.JournalApproves.Any(x => x.JournalId == journalId && x.Approved == 0);
        }


        ///<summary>
        /// Move a journal to a new hospital
        ///<param name="journalId">ID of the journal to be moved</param>
        ///<param name="hospitalID">The new hospital ID</param>
        /// </summary>
        public void MoveJournal(int journalId, int hospitalId)
        {
            _journalContext.Journals.Where(x => x.Id == journalId).First().HospitalId = hospitalId;
        }
        
        
        ///<summary>
        /// Get a journal based on journal ID
        ///<param name="journalIDd">ID of the journal to get</param>
        /// </summary>
        public Journal Get(int journalId)
        {
            return _journalContext.Journals.Where(x => x.Id == journalId).FirstOrDefault();
        }

        ///<summary>
        /// Get a list of journals by a users CPR number
        ///<param name="cpr">CPR number</param>
        /// </summary>
        public List<Journal> GetByCPR(int cpr)
        {
            return _journalContext.Journals.Where(x => x.AssignedPatient == cpr).ToList();
        }
    }
}