using Microsoft.AspNetCore.Mvc;
using System.Net;
using Heinekamp.Application.Features.DocumentTypes.Commands.CreateDocumentType;
using Heinekamp.Application.Features.DocumentTypes.Queries.GetDocumentTypes;

namespace Heinekamp.Api.Controllers;

public class DocumentTypesController : BaseApiController
{
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetDocumentTypesQuery(), cancellationToken);

        return Ok(result);
    }

    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        if (result == null)
        {
            BadRequest(result);
        }

        return Ok(result);
    }
}