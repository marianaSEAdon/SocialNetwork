
using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class CommentService: GenericService<Comment, CommentDto>, ICommentService
    {
        ICommentRepository _commentRepository;
        IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper): base(commentRepository, mapper)
        {
            _commentRepository = commentRepository; 
            _mapper = mapper;
        }
    }
}
