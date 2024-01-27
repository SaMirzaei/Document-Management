using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Exceptions;
using Heinekamp.Application.Services;
using Heinekamp.Application.Models;
using Heinekamp.Application.Extensions;
using System.Collections.Generic;

namespace Heinekamp.Application.Features.Documents.Commands.CreateDocumentWithMultipleFile
{
    public class CreateDocumentWithMultipleFileCommandHandler : IRequestHandler<CreateDocumentWithMultipleFileCommand, Response<List<long>>>
    {
        private readonly IDocumentService _documentService;

        public CreateDocumentWithMultipleFileCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<List<long>>> Handle(CreateDocumentWithMultipleFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Implement logic to handle multiple document uploads
                var documentIds = new List<long>();

                foreach (var model in request.Items)
                {
                    var documentDTO = new DocumentDTO
                    {
                        Name = model.Name,
                        ContentType = model.ContentType,
                        Content = model.File.OpenReadStream().ToByteArray(),
                    };

                    var documentId = await _documentService.UploadDocumentAsync(documentDTO);
                    documentIds.Add(documentId);
                }

                return new Response<List<long>>(documentIds);
            }
            catch
            {
                throw new ApiExceptions("Can not save documentType!");
            }
        }
    }
}
