using AutoMapper;
using SignalR.Dto.ContantDto;
using SignalR.Entity.Entities;

namespace SignalRApi.GenerelMapping
{
    public class ContantMapping:Profile
    {
        public ContantMapping()
        {
            CreateMap<Contant, ResultContantDto>().ReverseMap();
            CreateMap<Contant, CreateContantDto>().ReverseMap();
            CreateMap<Contant, ResultContantDto>().ReverseMap();
            CreateMap<Contant, GetContantDto>().ReverseMap();
        }
    }
}
