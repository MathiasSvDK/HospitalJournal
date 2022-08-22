using BlazorIdentityServerTest.Models;
using Contabo.ObjectStorage.S3;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorIdentityServerTest.Services
{
    public class AttachmentService
    {
        public ContaboS3Client Client { get; set; }
        public JournalContext _journalContext { get; set; }
        public AttachmentService(JournalContext _context)
        {
            Client = new ContaboS3Client();
            _journalContext = _context;
        }

        public async Task<Attachment> UploadFile(IBrowserFile file, string filename, int journalId)
        {
            try
            {
                ContaboS3File upload = await Client.UploadFileAsync(file.OpenReadStream(50000000), file.Name, "journal_attachments", "skole");
                return new Attachment()
                {
                    Type = file.Name.Split(".").Last().ToLower(),
                    Uri = upload.FileUrl,
                    Filename = file.Name
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public void Remove(Attachment att)
        {
            _journalContext.Attachments.Remove(att);
        }
        public void Remove(List<Attachment> att)
        {
            _journalContext.Attachments.RemoveRange(att);
        }

        public void Save()
        {
            _journalContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _journalContext.SaveChangesAsync();
        }

        public void Add(Attachment att)
        {
            _journalContext.Attachments.Add(att);
        }

        public List<Attachment> GetAttachments(int journalId)
        {
            return _journalContext.Attachments.Where(x => x.JournalId == journalId).ToList();
        }
    }
}