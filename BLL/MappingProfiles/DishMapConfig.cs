
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.MappingProfiles
{
    public class DishMapConfig:Profile
    {
        public DishMapConfig()
        {
            CreateMap<DishDTO, Dish>();
            CreateMap<Dish, DishDTO>();
        }
    }
}
