using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.MappingProfiles
{
    public class TableMapConfig : Profile
    {
        public TableMapConfig()
        {
            CreateMap<TableDTO, Table>();
            CreateMap<Table, TableDTO>();
        }
    }
}
