using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Models;
using Heinekamp.Application.Services;

namespace Heinekamp.Application.Features.Documents.Queries.GetDocumentById
{
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, Response<DocumentDTO>>
    {
        private readonly IDocumentService _documentService;

        public GetDocumentByIdQueryHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<DocumentDTO>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetDocumentByIdAsync(request.DocumentId);

            return new Response<DocumentDTO>(document);
        }
    }
}
