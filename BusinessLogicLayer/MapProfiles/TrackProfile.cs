using AutoMapper;
using Base.BusinessModels;
using DataLayer.DTO;

namespace BusinessLogicLayer.MapProfiles
{
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            CreateMap<Track, TrackEntity>().ReverseMap();
        } 
    }
}
