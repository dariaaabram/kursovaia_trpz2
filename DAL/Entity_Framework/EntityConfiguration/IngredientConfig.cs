using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Entity_Framework.EntityConfiguration
{
    class IngredientConfig : EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfig()
        {
            Property(f => f.Name).IsRequired();
            HasMany(d => d.Dishes)
             .WithMany(d => d.Ingredients)
             .Map(t => t.MapLeftKey("IngredientId")
             .MapRightKey("DishId")
             .ToTable("DishIngredient"));
        }
    }
}
