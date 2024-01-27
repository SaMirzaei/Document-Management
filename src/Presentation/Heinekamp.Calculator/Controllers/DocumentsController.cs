using Heinekamp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Heinekamp.Application.Features.Documents.Commands.CreateDocument;
using Heinekamp.Application.Features.Documents.Commands.CreateDocumentWithMultipleFile;
using Heinekamp.Application.Features.Documents.Commands.ShareLink;
using Heinekamp.Application.Features.Documents.Queries.GetAllDocuments;
using Heinekamp.Application.Features.Documents.Queries.GetDocumentById;

namespace Heinekamp.Api.Controllers;

public class DocumentsController : BaseApiController
{
    /// <summary>
    /// Get Documents
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var documents = await Mediator.Send(new GetDocumentsQuery());

        return Ok(documents);
    }

    /// <summary>
    /// GetDocumentById
    /// </summary>
    /// <param name="documentId"></param>
    /// <returns></returns>
    [HttpGet("{documentId}")]
    public async Task<IActionResult> Get(int documentId)
    {
        var result = await Mediator.Send(new GetDocumentByIdQuery
        {
            DocumentId = documentId
        });

        return Ok(result);
    }

    /// <summary>
    /// UploadDocument
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] DocumentUploadModel model)
    {
        var result = await Mediator.Send(new CreateDocumentCommand
        {
            Name = model.Name,
            ContentType = model.File.ContentType,
            File = model.File
        });

        return CreatedAtAction(nameof(Post), new { result }, null);
    }

    /// <summary>
    /// UploadMultipleDocuments
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    [HttpPost("multiple")]
    public async Task<IActionResult> Post([FromForm] List<DocumentUploadModel> models)
    {
        var result = await Mediator.Send(new CreateDocumentWithMultipleFileCommand
        {
            Items = models.Select(t => new Doc
            {
                Name = t.Name,
                //ContentType = t.ContentType,
                File = t.File
            }).ToList()
        });

        return Ok(result);
    }

    /// <summary>
    /// GenerateShareLink
    /// </summary>
    /// <param name="documentId"></param>
    /// <param name="expiryTime"></param>
    /// <returns></returns>
    [HttpGet("{documentId}/share/{expiryTime}")]
    public async Task<IActionResult> ShareLink(int documentId, int expiryTime)
    {
        var result = await Mediator.Send(new ShareLinkCommand
        {
            DocumentId = documentId,
            ExpiryTime = expiryTime
        });

        return Ok(result);
    }

    /// <summary>
    /// GenerateShareLink
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("/share/{token}")]
    public async Task<IActionResult> GetLink(string token)
    {
        //var result = await Mediator.Send(new ShareLinkCommand
        //{
        //    DocumentId = documentId,
        //    ExpiryTime = expiryTime
        //});

        //return Ok(result);
        return Ok();
    }
}