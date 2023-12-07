using System.ComponentModel;

namespace OnlineShop.Core.Domain.Common
{
    public class BaseAuditableEntity<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedOn { get; set; }
        public TKey CreatedBy { get; set; } = default!;
        public DateTime? ModifiedOn { get; set; }
        public TKey? ModifiedBy { get; set; }
    }

    public class BaseAuditableEntity : BaseAuditableEntity<long> { }
}