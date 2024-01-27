using Heinekamp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Heinekamp.Application.Features.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommand : IRequest<Response<long>>
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public IFormFile File { get; set; }
    }
}
