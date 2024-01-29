using Heinekamp.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Heinekamp.Application.Exceptions;
using Heinekamp.Application.Services;

namespace Heinekamp.Application.Features.Documents.Commands.ShareLink
{
    public class ShareLinkCommandHandler : IRequestHandler<ShareLinkCommand, Response<string>>
    {
        private readonly IDocumentService _documentService;

        public ShareLinkCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Response<string>> Handle(ShareLinkCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shareLink = await _documentService.GenerateShareLink(request.DocumentId, request.ExpiryTime);

                return new Response<string>
                {
                    Data = shareLink
                };
            }
            catch
            {
                throw new ApiExceptions("Can not create share link!");
            }
        }
    }
}
