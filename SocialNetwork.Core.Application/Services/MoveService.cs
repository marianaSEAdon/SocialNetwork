using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Move;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class MoveService: GenericService<Move, MoveDto>, IMoveService
    {
        
        private readonly IMoveRepository _moveRepository;
        private readonly IMapper _mapper;

        public MoveService(IMoveRepository moveRepository, IMapper mapper) : base(moveRepository, mapper) 
        {
            _moveRepository = moveRepository;
            _mapper = mapper;   
        }

    }
}
