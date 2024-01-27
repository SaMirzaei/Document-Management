using Heinekamp.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using Heinekamp.Application.Models;

namespace Heinekamp.Application.Features.Documents.Queries.GetAllDocuments
{
    public class GetDocumentsQuery : IRequest<Response<List<DocumentDTO>>>
    {
    }
}
