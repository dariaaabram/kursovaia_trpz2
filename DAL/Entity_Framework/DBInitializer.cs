
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Entity_Framework
{
    public sealed class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            var ingredient1 = new Ingredient {Name= "Carrot" };
            var ingredient2 = new Ingredient { Name = "Sugar" };
            var ingredient3 = new Ingredient { Name = "Apple" };
           
            var dish1 = new Dish { Name = "Carrot pie", Price = 10, Weight = 100 };
             dish1.Ingredients.Add(ingredient1);
            ingredient1.Dishes.Add(dish1);
            dish1.Ingredients.Add(ingredient2);
            ingredient2.Dishes.Add(dish1);
            var dish2 = new Dish { Name = "Apple pie", Price = 15, Weight = 150 };
            dish2.Ingredients.Add(ingredient3);
            ingredient3.Dishes.Add(dish2);
            dish2.Ingredients.Add(ingredient2);
            ingredient2.Dishes.Add(dish2);
            var table1 = new Table { PeopleAmount = 2 };
            var table2 = new Table { PeopleAmount = 3 };
            var table3 = new Table { PeopleAmount =6 };
            // var order = new Order { Name = "Carrot Only Order", TableId = 1 };
            //order.Dishes.Add(dish);
            //order.Price += dish.Price;
            db.Ingredients.Add(ingredient1);
            db.Ingredients.Add(ingredient2);
            db.Ingredients.Add(ingredient3);
           
            db.Dishes.Add(dish1);
            db.Dishes.Add(dish2);
           // db.Tables.Add(table);
            //db.Orders.Add(order);
            db.Tables.Add(table1);
            db.Tables.Add(table2);
            db.Tables.Add(table3);
            db.SaveChanges();

        }
    }
}