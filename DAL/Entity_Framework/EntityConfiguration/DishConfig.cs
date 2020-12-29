using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Entity_Framework.EntityConfiguration
{
    class DishConfig : EntityTypeConfiguration<Dish>
    {
        public DishConfig()
        {
            Property(f => f.Name).IsRequired();
            Property(f => f.Price).IsRequired();
            Property(f => f.Weight).IsRequired();
            Property(f => f.Time).IsRequired();
        }
    }
}
