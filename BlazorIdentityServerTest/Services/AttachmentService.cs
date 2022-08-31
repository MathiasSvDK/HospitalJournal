using BlazorIdentityServerTest.Models;
using Contabo.ObjectStorage.S3;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services
{
    public class AttachmentService : IAttachmentService
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
                    //Get the file type by splitting at . and selecting the Last. 
                    //Example "mypdf.pdf" will be a "pdf" file, becuase ".pdf" is the last.
                    Type = file.Name.Split(".").Last().ToLower(),
                    Uri = upload.FileUrl,
                    Filename = file.Name,
                    JournalId = journalId
                };
            }
            catch (System.Exception)
            {
                throw;
            }
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
        public List<Attachment> GetAttachments(List<int> attachmentIds)
        {
            return _journalContext.Attachments.Where(x => attachmentIds.Contains(x.Id)).ToList();
        }
    }
}