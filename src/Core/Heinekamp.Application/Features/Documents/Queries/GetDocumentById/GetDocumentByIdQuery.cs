using Heinekamp.Application.Wrappers;
using MediatR;
using Heinekamp.Application.Models;

namespace Heinekamp.Application.Features.Documents.Queries.GetDocumentById
{
    public class GetDocumentByIdQuery : IRequest<Response<DocumentDTO>>
    {
        public long DocumentId { get; set; }
    }
}
