using System;

namespace Heinekamp.Domain.Entities
{
    public class Document : BaseEntity<long>
    {
        public long DocumentTypeId { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public DateTime UploadDateTime { get; set; }
    }
}