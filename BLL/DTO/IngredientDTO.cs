using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class IngredientDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<DishDTO> Dishes { get; set; }
    }
}
