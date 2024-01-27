using Heinekamp.Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Heinekamp.Application.Features.DocumentTypes.Queries.GetDocumentTypes
{
    public class GetDocumentTypesQuery : IRequest<Response<List<string>>>
    {
    }
}
