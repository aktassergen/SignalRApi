using AutoMapper;
using SignalR.Dto.FeatureDto;
using SignalR.Dto.SliderDto;
using SignalR.Entity.Entities;

namespace SignalRApi.GenerelMapping
{
    public class SliderMapping:Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();
        }
    }
}
