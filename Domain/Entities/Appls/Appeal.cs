using Core.Domain.Entities;

namespace Domain.Entities.Appls;

public class Appeal : BaseAgreegateRoot
{
    public string Name { get; set; }
}