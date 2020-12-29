using System;
using System.Data.Entity;
using DAL.Repositories;
using DAL.Entity_Framework;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext c = new Context();
            UnitOfWork u = new UnitOfWork(c, new IngredientRepository(c), new DishRepository(c), new OrderRepository(c), new TableRepository(c));
            foreach(var x in u.Orders.GetAll())
            {
                Console.WriteLine(x.Name);
            }
            Console.WriteLine("All");
            Console.ReadKey();
        }
    }
}
