
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.User;
using SocialNetwork.Core.Application.ViewModels.User;

namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class UserDtoMappingProfile: Profile
    {
        public UserDtoMappingProfile()
        {

            CreateMap<SaveUserDto, RegisterUserViewModel>()
                .ForMember(dest => dest.ProfileImageFile, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ProfileImage, opt => opt.Ignore());

            CreateMap<UserDto, UserViewModel>().ReverseMap();

            CreateMap<LoginDto, LoginViewModel>()
                .ReverseMap();

          
        }
    }
}
