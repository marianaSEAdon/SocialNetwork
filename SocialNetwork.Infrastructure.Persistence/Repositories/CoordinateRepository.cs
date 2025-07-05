
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;
using SocialNetwork.Infrastructure.Persistence.Base;
using SocialNetwork.Infrastructure.Persistence.Contexts;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class CoordinateRepository : GenericRepository<Coordinate>, ICoordinateRepository
    {
        private readonly SocialNetworkContext _context;
        public CoordinateRepository(SocialNetworkContext context): base(context)
        {
            _context = context;
        }
    }
}
