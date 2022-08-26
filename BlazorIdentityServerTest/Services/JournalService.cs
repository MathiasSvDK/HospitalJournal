using BlazorIdentityServerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlazorIdentityServerTest.Services
{
    public class JournalService
    {
        public JournalContext _journalContext { get; set; }
        public JournalService(JournalContext _jContext)
        {
            _journalContext = _jContext;
        }

        public async Task<Journal> CreateJournal(Journal journal) {
            await _journalContext.Journals.AddAsync(journal);
            return journal;
        }

        public async Task SaveAsync()
        {
            await _journalContext.SaveChangesAsync();
        }



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


        public async Task ApproveChanges(JournalApprove approve)
        {
            //Get the journal and update the values
            Journal journal = _journalContext.Journals.Where(x => x.Id == approve.JournalId).First();
            journal.Text = approve.Text;
            List<Attachment> attachments = _journalContext.Attachments.Where(a => approve.NewAttachmentsList.Select(x => x.Id).ToList().Contains(a.Id)).ToList();
            foreach (Attachment att in attachments)
            {
                att.JournalId = journal.Id;
            }
            //Approve the approved
            approve.Approved = 1;


        }

        public void Denychanges(int approveId)
        {
            _journalContext.JournalApproves.Where(x => x.Id == approveId).FirstOrDefault().Approved = 2;
        }
        
        

        public JournalApprove GetJournalPending(int journalId)
        {
            return _journalContext.JournalApproves.Where(x => x.JournalId == journalId && x.Approved == 0).FirstOrDefault();
        }

        public bool HasPending(int journalId)
        {
            return _journalContext.JournalApproves.Any(x => x.JournalId == journalId && x.Approved == 0);
        }


        public void MoveJournal(int journalId, int hospitalId)
        {
            _journalContext.Journals.Where(x => x.Id == hospitalId).First().HospitalId = hospitalId;
        }
        
        
        public Journal Get(int journalId)
        {
            return _journalContext.Journals.Where(x => x.Id == journalId).FirstOrDefault();
        }

        public List<Journal> GetByCPR(int cpr)
        {
            return _journalContext.Journals.Where(x => x.AssignedPatient == cpr).ToList();
        }
    }
}