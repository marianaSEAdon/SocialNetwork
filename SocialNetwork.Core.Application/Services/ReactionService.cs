using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Reaction;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class ReactionService: GenericService<Reaction, ReactionDto>, IReactionService
    {
        private readonly IMapper _mapper;
        private readonly IReactionRepository _reactionRepository;
        public ReactionService(IReactionRepository reactionRepository, IMapper mapper): base(reactionRepository, mapper)
        {
            _mapper = mapper;
            _reactionRepository = reactionRepository;
        }
    }
}
