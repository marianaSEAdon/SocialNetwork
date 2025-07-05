using AutoMapper;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.Mappings.EntitiesAndDtos
{
    public class BasicMappingProfile: Profile
    {
        public BasicMappingProfile()
        {
            CreateMap(typeof(BaseDto<>), typeof(BaseEntity<>)).ReverseMap();
        }
    }
}
