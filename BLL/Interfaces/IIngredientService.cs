using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IIngredientService : IService<IngredientDTO>
    {
       void EditIngredient(int id, IngredientDTO ingredient);


        List<IngredientDTO> GetByWord(string word);
        

    }
}
