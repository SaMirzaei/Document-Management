namespace Heinekamp.Api.Models;

public class DocumentUploadModel
{
    public string Name { get; set; }
    //public string ContentType { get; set; }
    public IFormFile File { get; set; }
}