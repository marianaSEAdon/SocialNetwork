
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;
using SocialNetwork.Infrastructure.Persistence.Base;
using SocialNetwork.Infrastructure.Persistence.Contexts;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        private readonly SocialNetworkContext _context;
        public BoardRepository(SocialNetworkContext context): base(context) 
        {
            _context = context;
        }
    }
}
