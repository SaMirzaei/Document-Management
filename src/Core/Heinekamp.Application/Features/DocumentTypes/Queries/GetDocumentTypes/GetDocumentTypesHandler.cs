using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Services;
using Heinekamp.Application.Wrappers;
using MediatR;

namespace Heinekamp.Application.Features.DocumentTypes.Queries.GetDocumentTypes
{
    public class GetDocumentTypesHandler : IRequestHandler<GetDocumentTypesQuery, Response<List<string>>>
    {
        private readonly IDocumentService _documentService;

        public GetDocumentTypesHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<List<string>>> Handle(GetDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            var documentTypes = await _documentService.GetDocumentTypes();

            return new Response<List<string>>(documentTypes.ToList());
        }
    }
}
