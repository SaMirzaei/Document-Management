using Heinekamp.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heinekamp.Domain.Entities;
using System.IO;

namespace Heinekamp.Application.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDTO>> GetDocumentsAsync();

        Task<DocumentDTO> GetDocumentByIdAsync(long documentId);

        Task<long> UploadDocumentAsync(DocumentDTO documentDTO);
        
        Task<string> GenerateShareLink(int documentId, int expiryTime);

        Task<IEnumerable<string>> GetDocumentTypes();

        Task<DocumentType> AddDocumentTypeAsync(DocumentType documentType);

        Task<Stream> DownloadDocumentAsync(long documentId);

        Task IncreaseDownload(long documentId);
    }
}
