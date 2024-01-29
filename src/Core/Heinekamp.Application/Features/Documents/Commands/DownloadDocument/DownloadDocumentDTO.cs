using System.IO;

namespace Heinekamp.Application.Features.Documents.Commands.DownloadDocument
{
    public class DownloadDocumentDTO
    {
        public Stream Stream { get; set; }

        public string FileName { get; set; }

        public string Mime { get; set; }
    }
}
