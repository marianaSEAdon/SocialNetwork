using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.GameSession;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class GameSessionService : GenericService<GameSession, GameSessionDto>, IGameSessionService
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly IMapper _mapper;
        public GameSessionService(IGameSessionRepository gameSessionRepository, IMapper mapper): base(gameSessionRepository, mapper)
        {
            _gameSessionRepository = gameSessionRepository;
            _mapper = mapper;
        }
    }
}
