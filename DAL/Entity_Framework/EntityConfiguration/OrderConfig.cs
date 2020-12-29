using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Entity_Framework.EntityConfiguration
{
    class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            Property(f => f.Name).IsRequired();
            Property(f => f.TableId).IsRequired();
            Property(f => f.Price).IsRequired();
            HasMany(d => d.Dishes)
               .WithMany(d => d.Orders)
               .Map(t => t.MapLeftKey("OrderId")
               .MapRightKey("DishId")
               .ToTable("DishOrder"));
        }
    }
}