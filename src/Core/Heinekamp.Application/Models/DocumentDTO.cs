using System;

namespace Heinekamp.Application.Models
{
    public class DocumentDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Downloads { get; set; }

        public DocumentTypeDTO DocumentType { get; set; }
    }
}