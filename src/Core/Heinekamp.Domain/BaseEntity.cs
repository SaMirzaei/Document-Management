namespace Heinekamp.Domain
{
    public class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }
    }
}
