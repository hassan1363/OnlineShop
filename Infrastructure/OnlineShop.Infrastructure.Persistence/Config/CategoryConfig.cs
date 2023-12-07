using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence.Config
{
    public class CategoryConfig : BaseAuditableConfig<Category, long>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            //builder.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
            base.Configure(builder);
        }
    }
}
