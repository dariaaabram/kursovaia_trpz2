using System.Collections.Generic;

namespace DAL.Entities
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }

        public Ingredient()
        {
            Dishes = new List<Dish>();
        }
    }
}