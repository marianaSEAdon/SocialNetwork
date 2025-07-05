
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.FriendRequest;
using SocialNetwork.Core.Application.Dtos.User;
using SocialNetwork.Core.Application.ViewModels.FriendRequest;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class FriendRequestDtoMappingProfile : Profile
    {
        public FriendRequestDtoMappingProfile()
        {
            CreateMap<CreateFriendRequestViewModel, FriendRequestDto>().ReverseMap();
            CreateMap<FriendRequestViewModel, FriendRequestDto>().ReverseMap();

            CreateMap<FriendRequest, FriendRequestDto>().ReverseMap();

            CreateMap<UpdateFriendRequestViewModel, FriendRequestDto>().ReverseMap();

        }
    }
}
