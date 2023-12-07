using OnlineShop.Core.Domain.Common;

namespace OnlineShop.Core.Domain.Entities;

public class Category : BaseAuditableEntity<long>
{
    public string Name { get; set; } = null!;
    public long? ParentId { get; set; }
    public Category? Parent { get; set; }
    public List<Category>? Children { get; set; }
}