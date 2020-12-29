using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.MappingProfiles
{
    public class OrderMapConfig : Profile
    {
        public OrderMapConfig()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
