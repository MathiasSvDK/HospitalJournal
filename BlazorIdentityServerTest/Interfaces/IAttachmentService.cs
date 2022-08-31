using BlazorIdentityServerTest.Models;
using Contabo.ObjectStorage.S3;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorIdentityServerTest.Interfaces;

public interface IAttachmentService
{
    ContaboS3Client Client { get; set; }
    JournalContext _journalContext { get; set; }
    Task<Attachment> UploadFile(IBrowserFile file, string filename, int journalId);
    Task SaveAsync();
    void Add(Attachment att);
    List<Attachment> GetAttachments(int journalId);
    List<Attachment> GetAttachments(List<int> attachmentIds);
}