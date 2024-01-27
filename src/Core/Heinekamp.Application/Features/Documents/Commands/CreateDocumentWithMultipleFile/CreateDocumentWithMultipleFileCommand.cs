using System.Collections.Generic;
using Heinekamp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Heinekamp.Application.Features.Documents.Commands.CreateDocumentWithMultipleFile
{
    public class CreateDocumentWithMultipleFileCommand : IRequest<Response<List<long>>>
    {
        public List<Doc> Items { get; set; } = new List<Doc>();
    }

    public class Doc
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public IFormFile File { get; set; }
    }
}
