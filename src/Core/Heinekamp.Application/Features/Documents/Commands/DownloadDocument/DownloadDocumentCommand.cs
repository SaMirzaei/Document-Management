using Heinekamp.Application.Wrappers;
using MediatR;

namespace Heinekamp.Application.Features.Documents.Commands.DownloadDocument
{
    public class DownloadDocumentCommand : IRequest<Response<DownloadDocumentDTO>>
    {
        public long DocumentId { get; set; }
    }
}
