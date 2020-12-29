using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.MappingProfiles
{
    public class IngredientMapConfig : Profile
    {
        public IngredientMapConfig()
        {
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>();
        }
    }
}
