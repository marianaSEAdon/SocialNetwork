

using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.ViewModels.Comment;


namespace SocialNetwork.Core.Application.Mappings.DtosAndViewModels
{
    public class CommentDtoMappingProfile: Profile
    {
        public CommentDtoMappingProfile()
        {
            CreateMap<CommentDto, CommentViewModel>()
            .ForMember(dest => dest.RepliedComment, opt => opt.Ignore())
            .ForMember(dest => dest.Replies, opt => opt.Ignore())
            .ForMember(dest => dest.Post, opt => opt.Ignore())
            .ReverseMap();
            
        }
    }
}
