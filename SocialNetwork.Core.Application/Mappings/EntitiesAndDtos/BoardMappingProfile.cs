
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Board;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Core.Application.Mappings.EntitiesAndDtos
{
    public class BoardMappingProfile: Profile
    {
        public BoardMappingProfile()
        {
            CreateMap<Board, BoardDto>()
                .ForMember(dest => dest.Coordinates,
        opt => opt.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Ships,
        opt => opt.MapFrom(src => src.Ships))
                .ReverseMap()
                .ForMember(dest => dest.Coordinates, opt => opt.Ignore())
                .ForMember(dest => dest.Ships, opt => opt.Ignore());
        }
    }
}
