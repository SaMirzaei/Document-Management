namespace Heinekamp.Api.Models;

public class DocumentUploadModel
{
    public string Name { get; set; }

    public IFormFile File { get; set; }
}