using System.Data.Entity;
using DAL.Entities;
using DAL.Entity_Framework.Conventions;
using DAL.Entity_Framework.EntityConfiguration;

namespace DAL.Entity_Framework
{
    public sealed class Context : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }

        static Context()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public Context() : base("Entity")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new StringConvention());
            modelBuilder.Configurations.Add(new IngredientConfig());
            modelBuilder.Configurations.Add(new DishConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new TableConfig());
        }
    }
}
