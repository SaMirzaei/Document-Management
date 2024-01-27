using Heinekamp.Application.Wrappers;
using MediatR;

namespace Heinekamp.Application.Features.DocumentTypes.Commands.CreateDocumentType
{
    public class CreateDocumentTypeCommand : IRequest<Response<long>>
    {
        public string Name { get; set; }
    }
}
