using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Exceptions;
using Heinekamp.Application.Services;
using Heinekamp.Application.Models;
using Heinekamp.Application.Extensions;

namespace Heinekamp.Application.Features.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Response<long>>
    {
        private readonly IDocumentService _documentService;

        public CreateDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<long>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Implement logic to handle document upload
                var documentDTO = new DocumentDTO
                {
                    Name = request.Name,
                    ContentType = request.ContentType,
                    Content = request.File.OpenReadStream().ToByteArray(),
                    FileName = request.File.FileName
                };
                
                
                var documentId = await _documentService.UploadDocumentAsync(documentDTO);

                return new Response<long>(documentId);
            }
            catch
            {
                throw new ApiExceptions("Can not save documentType!");
            }
        }
    }
}
