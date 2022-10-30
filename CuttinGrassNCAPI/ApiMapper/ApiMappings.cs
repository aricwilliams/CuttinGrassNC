using CuttinGrassNCAPI.Model.DBCustomers;
using AutoMapper;
using CuttinGrassNCAPI.Model.DBCustomers.Dtos;

namespace CuttinGrassNCAPI.ApiMapper
{
    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            CreateMap<Customers, CustomerDto>().ReverseMap();
        }   
             
    }
}
