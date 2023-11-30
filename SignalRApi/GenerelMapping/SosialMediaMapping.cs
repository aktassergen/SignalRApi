using AutoMapper;
using SignalR.Dto.SosialMediaDto;
using SignalR.Entity.Entities;

namespace SignalRApi.GenerelMapping
{
    public class SosialMediaMapping:Profile
    {
        public SosialMediaMapping()
        {
            CreateMap<SosialMedia, ResultSosialMediaDto>().ReverseMap();
            CreateMap<SosialMedia, CreateSosialMediaDto>().ReverseMap();
            CreateMap<SosialMedia, ResultSosialMediaDto>().ReverseMap();
            CreateMap<SosialMedia, GetSosialMediaDto>().ReverseMap();
        }
    }
}
