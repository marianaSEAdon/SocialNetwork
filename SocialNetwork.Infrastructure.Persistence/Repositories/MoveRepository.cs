

using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;
using SocialNetwork.Infrastructure.Persistence.Base;
using SocialNetwork.Infrastructure.Persistence.Contexts;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class MoveRepository: GenericRepository<Move>, IMoveRepository
    {
        private readonly SocialNetworkContext _context;
        public MoveRepository(SocialNetworkContext context): base(context) 
        {
            _context = context;
        }
    }
}
