using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOrderService : IService<OrderDTO>
    {
       bool CheckTableExistance(int Id);
        void EditOrderTable(int id, OrderDTO order);
        void EditOrderDishesAmount(int orderId, int dishId, int amount);
       List<OrderDTO> GetByWord(string word);
    }
}
