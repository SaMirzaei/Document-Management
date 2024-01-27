using Heinekamp.Application.Wrappers;
using MediatR;

namespace Heinekamp.Application.Features.Documents.Commands.ShareLink
{
    public class ShareLinkCommand : IRequest<Response<string>>
    {
        public int DocumentId { get; set; }
        public int ExpiryTime { get; set; }
    }
}
