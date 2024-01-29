using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Services;

namespace Heinekamp.Application.Features.Documents.Commands.DownloadDocument
{
    public class DownloadDocumentCommandHandler : IRequestHandler<DownloadDocumentCommand, Response<DownloadDocumentDTO>>
    {
        private readonly IDocumentService _documentService;

        public DownloadDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<DownloadDocumentDTO>> Handle(DownloadDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetDocumentByIdAsync(request.DocumentId);

            if (document == null)
            {
                return new Response<DownloadDocumentDTO>(null, "Document not found");
            }

            var stream = await _documentService.DownloadDocumentAsync(document.Id);

            if (stream == null)
            {
                return new Response<DownloadDocumentDTO>(null, "Document not found");
            }

            await _documentService.IncreaseDownload(document.Id);

            return new Response<DownloadDocumentDTO>(new DownloadDocumentDTO
            {
                Stream = stream,
                FileName = document.FileName,
                Mime = document.DocumentType.Mime
            });
        }
    }
}
