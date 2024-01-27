using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Exceptions;
using Heinekamp.Application.Services;
using Heinekamp.Domain.Entities;

namespace Heinekamp.Application.Features.DocumentTypes.Commands.CreateDocumentType
{
    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, Response<long>>
    {
        private readonly IDocumentService _documentService;

        public CreateDocumentTypeCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<long>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var documentType = new DocumentType
                {
                    Name = request.Name
                };

                var createdDocumentType = await _documentService.AddDocumentTypeAsync(documentType);

                return new Response<long>(createdDocumentType.Id);
            }
            catch
            {
                throw new ApiExceptions("Can not save documentType!");
            }
        }
    }
}
