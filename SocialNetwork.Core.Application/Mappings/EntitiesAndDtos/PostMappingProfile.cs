
using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Dtos.Post;
using SocialNetwork.Core.Application.Dtos.Reaction;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Core.Application.Mappings.EntitiesAndDtos
{
    public class PostMappingProfile: Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CommentDto, CommentViewModel>()
            .ForMember(dest => dest.RepliedComment, opt => opt.Ignore())
            .ForMember(dest => dest.Replies, opt => opt.Ignore())
            .ForMember(dest => dest.Post, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<Comment, CommentDto>()
           .ForMember(dest => dest.RepliedComment, opt => opt.Ignore())
           .ForMember(dest => dest.Replies, opt => opt.Ignore()) 
           .ForMember(dest => dest.Post, opt => opt.Ignore()) 
           .ReverseMap()
           .ForMember(dest => dest.Replies, opt => opt.Ignore())
           .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Reactions,
        opt => opt.MapFrom(src => src.Reactions))
                .ForMember(dest => dest.Comments,
        opt => opt.MapFrom(src => src.Comments))
                .ReverseMap()
                .ForMember(dest => dest.Reactions, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore());


            CreateMap<Reaction, ReactionDto>();
        }
    }
}
