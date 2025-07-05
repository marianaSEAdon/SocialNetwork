
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Dtos.Reaction;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Reaction;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class ReactionDtoMappingProfile: Profile
    {
        public ReactionDtoMappingProfile()
        {

            CreateMap<Reaction, ReactionDto>()
          .ForMember(dest => dest.Post, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<ReactionDto, ReactionViewModel>()
            .ForMember(dest => dest.Post, opt => opt.Ignore())
            .ReverseMap();


        }

    }
}
