using Heinekamp.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Models;
using Heinekamp.Application.Services;

namespace Heinekamp.Application.Features.Documents.Queries.GetAllDocuments
{
    public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, Response<List<DocumentDTO>>>
    {
        private readonly IDocumentService _documentService;

        public GetDocumentsQueryHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<List<DocumentDTO>>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentService.GetDocumentsAsync();

            return new Response<List<DocumentDTO>>(documents.ToList());
        }
    }
}
