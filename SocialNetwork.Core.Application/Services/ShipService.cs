using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Ship;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class ShipService: GenericService<Ship, ShipDto>, IShipService
    {
        private readonly IShipRepository _shipRepository;
        private readonly IMapper _mapper;
        public ShipService(IShipRepository shipRepository, IMapper mapper): base(shipRepository, mapper)
        {
            _shipRepository = shipRepository;
            _mapper = mapper;
        }
    }
}
