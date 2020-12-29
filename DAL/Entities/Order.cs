using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int TableId { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }

        public Order()
        {
            Dishes = new List<Dish>();
        }

    }
}
