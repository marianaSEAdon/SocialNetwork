
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Persistence.Contexts
{
    public class SocialNetworkContext: DbContext
    {
        public SocialNetworkContext(DbContextOptions <SocialNetworkContext> options): base(options)
        {
        }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Move> Moves { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
       
    }
}
