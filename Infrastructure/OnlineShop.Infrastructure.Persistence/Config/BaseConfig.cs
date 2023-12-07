using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Domain.Common;

namespace OnlineShop.Infrastructure.Persistence.Config
{
    public abstract class BaseConfig<TBase, TKey> : IEntityTypeConfiguration<TBase>
        where TBase : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
        {
            //Base Configuration
        }
    }

    public abstract class BaseAuditableConfig<TBase, TKey> : IEntityTypeConfiguration<TBase>
     where TBase : BaseAuditableEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getdate()");
        }
    }
}
