namespace Heinekamp.Domain.Entities
{
    public class DocumentType : BaseEntity<long>
    {
        public string Name { get; set; }

        public string Mime { get; set; }

        public string Icon { get; set; }
    }
}