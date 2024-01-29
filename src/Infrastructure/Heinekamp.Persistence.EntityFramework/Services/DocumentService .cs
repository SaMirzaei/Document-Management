using Heinekamp.Application.Models;
using Heinekamp.Application.Repositories;
using Heinekamp.Application.Services;
using Heinekamp.Domain.Entities;

namespace Heinekamp.Persistence.EntityFramework.Services;

public class DocumentService : IDocumentService
{
    private readonly IFileStorageService _fileStorageService;
    private readonly IRepository<Document> _documentRepository;
    private readonly IRepository<DocumentType> _documentTypeRepository;
    private readonly IRepository<ShareLink> _shareLinkRepository;

    public DocumentService(
        IFileStorageService fileStorageService, 
        IRepository<Document> documentRepository, 
        IRepository<DocumentType> documentTypeRepository,
        IRepository<ShareLink> shareLinkRepository)
    {
        _fileStorageService = fileStorageService;
        _documentRepository = documentRepository;
        _documentTypeRepository = documentTypeRepository;
        _shareLinkRepository = shareLinkRepository;
    }

    public async Task<IEnumerable<DocumentDTO>> GetDocumentsAsync()
    {
        var documents = await _documentRepository.GetAllAsyncIncluding(t => t.DocumentType);

        return documents.Select(MapToDocumentDTO);
    }

    public async Task<DocumentDTO> GetDocumentByIdAsync(long documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId, t => t.DocumentType);
        
        return MapToDocumentDTO(document);
    }

    public async Task<long> UploadDocumentAsync(DocumentDTO documentDTO)
    {
        var document = new Document
        {
            Name = documentDTO.Name,
            ContentType = documentDTO.ContentType,
            CreatedAt = documentDTO.CreatedAt
        };

        var documentTypeId = GetDocumentTypeIdByName(documentDTO.ContentType);
        document.DocumentTypeId = documentTypeId;

        var fileName = await _fileStorageService.SaveFileAsync(documentDTO.FileName, documentDTO.Content);
        document.FileName = fileName;

        await _documentRepository.AddAsync(document);

        return document.Id;
    }

    public async Task<string> GenerateShareLink(int documentId, int expiryTime)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            throw new NullReferenceException("Document not found");
        }

        var shareToken = Guid.NewGuid().ToString();

        // Associate the token with the document and set the expiry time
        var shareLink = new ShareLink
        {
            Token = shareToken,
            DocumentId = document.Id,
            ExpiryTime = DateTime.UtcNow.AddHours(expiryTime)
        };

        await _shareLinkRepository.AddAsync(shareLink);

        return shareToken;
    }

    public async Task<IEnumerable<string>> GetDocumentTypes()
    {
        var documentTypes = await _documentTypeRepository.GetAllAsync();

        // Extract distinct document type names
        var distinctDocumentTypes = documentTypes.Select(dt => dt.Name).Distinct();

        return distinctDocumentTypes;
    }

    public async Task<DocumentType> AddDocumentTypeAsync(DocumentType documentType)
    {
        // Validate and handle logic for adding a new document type
        var existingDocumentType = await _documentTypeRepository.FirstOrDefaultAsync(dt => dt.Name == documentType.Name);

        if (existingDocumentType != null)
        {
            throw new Exception("Document type already exists.");
        }

        var newDocumentType = new DocumentType
        {
            Name = documentType.Name
        };

        var addedDocumentType = await _documentTypeRepository.AddAsync(newDocumentType);

        return addedDocumentType;
    }

    public async Task<Stream> DownloadDocumentAsync(long documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            return null;
        }

        var content = _fileStorageService.GetFileStreamAsync(document.FileName);

        return content;
    }

    public async Task IncreaseDownload(long documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            return;
        }

        document.Downloads++;

        await _documentRepository.UpdateAsync(document);
    }

    private DocumentDTO MapToDocumentDTO(Document document)
    {
        return new DocumentDTO
        {
            Id = document.Id,
            Name = document.Name,
            ContentType = document.ContentType,
            FileName = document.FileName,
            Content = document.Content,
            CreatedAt = document.CreatedAt,
            Downloads = document.Downloads,
            DocumentType = new DocumentTypeDTO
            {
                Id = document.DocumentTypeId,
                Name = document.DocumentType.Name,
                Icon = document.DocumentType.Icon,
                Mime = document.DocumentType.Mime
            }
        };
    }

    private long GetDocumentTypeIdByName(string typeName)
    {
        var documentType = _documentTypeRepository.FirstOrDefault(x => x.Mime == typeName);

        return documentType?.Id ?? 0;
    }
}