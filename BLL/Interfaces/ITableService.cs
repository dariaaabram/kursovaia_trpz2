using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITableService:IService<TableDTO>
    {
        void EditTable(int id, TableDTO table);
       
    }
}
