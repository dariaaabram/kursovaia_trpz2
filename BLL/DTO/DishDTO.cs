using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DishDTO:IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }

        public float Time { get; set; }
        public ICollection<IngredientDTO> Ingredients { get; set; }
        public ICollection<OrderDTO> Orders { get; set; }
    }
}
