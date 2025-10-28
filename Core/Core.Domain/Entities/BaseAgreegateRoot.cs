namespace Core.Domain.Entities
{
    public class BaseAgreegateRoot : BaseEntity
    {
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}