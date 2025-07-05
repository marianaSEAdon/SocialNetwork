
using AutoMapper;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.ViewModels;

namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class BasicDtoMappingProfile: Profile
    {
        public BasicDtoMappingProfile()
        {
            CreateMap(typeof(BaseDto<>), typeof(BaseViewModel<>)).ReverseMap();
        }
    }
}
