using System;

namespace Heinekamp.Domain.Entities
{
    public class ShareLink : BaseEntity<long>
    {
        public string Token { get; set; }

        public long DocumentId { get; set; }

        public DateTime ExpiryTime { get; set; }
    }
}