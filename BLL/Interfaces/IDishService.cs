

using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IDishService:IService<DishDTO>
    {
        void EditDishPrice(int id, DishDTO dish);

        void EditDishWeight(int id, DishDTO dish);
        void EditDishName(int id, DishDTO dish);

        void EditDishTime(int id, DishDTO dish);

         void AddDishIngredient(int dishId, int ingredientId);

        void DeleteDishIngredient(int dishId, int ingredientId);
        
    }
}
