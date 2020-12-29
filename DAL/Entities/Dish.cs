using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public float Time { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Dish()
        {
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
        }
    }
}
