using System.Collections.Generic;

namespace Heinekamp.Domain.Entities
{
    public class DocumentType : BaseEntity<long>
    {
        public string Name { get; set; }

        public string Mime { get; set; }

        public string Icon { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}