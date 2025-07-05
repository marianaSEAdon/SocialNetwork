using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Coordinate;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class CoordinateService : GenericService<Coordinate, CoordinateDto>, ICoordinateService
    {
        private readonly ICoordinateRepository _coordinateRepository;
        private readonly IMapper _mapper;
        public CoordinateService(ICoordinateRepository coordinateRepository, IMapper mapper) : base(coordinateRepository, mapper) 
        {
            _coordinateRepository = coordinateRepository;
            _mapper = mapper;
        } 
    }
}
