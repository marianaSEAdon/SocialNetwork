
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Post;
using SocialNetwork.Core.Application.ViewModels.Post;

namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class PostDtoMappingProfile: Profile
    {
        public PostDtoMappingProfile()
        {
            CreateMap<PostDto, PostViewModel>()
                .ForMember(dest => dest.Comments,
                           opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Reactions,
                           opt => opt.MapFrom(src => src.Reactions))
                .ReverseMap()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Reactions, opt => opt.Ignore());


            CreateMap<PostDto, CreatePostViewModel>()
                .ForMember(dest => dest.Comments,
                           opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Reactions,
                           opt => opt.MapFrom(src => src.Reactions))
                .ReverseMap()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Reactions, opt => opt.Ignore());

            CreateMap<CreatePostViewModel, PostDto>();

        }
    }
}
