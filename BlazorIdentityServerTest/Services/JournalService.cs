using BlazorIdentityServerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorIdentityServerTest.Services
{
    public class JournalService
    {
        public JournalContext _journalContext { get; set; }
        public JournalService(JournalContext _context)
        {
            _journalContext = _context;
        }

        public async Task<Journal> CreateJournal(Journal journal) {
            await _journalContext.Journals.AddAsync(journal);
            return journal;
        }

        public async Task SaveAsync()
        {
            await _journalContext.SaveChangesAsync();
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