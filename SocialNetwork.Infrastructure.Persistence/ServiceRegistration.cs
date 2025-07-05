

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Domain.Interfaces;
using SocialNetwork.Infrastructure.Persistence.Base;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using SocialNetwork.Infrastructure.Persistence.Repositories;

namespace SocialNetwork.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayerIoc(this IServiceCollection services, IConfiguration config)
        {

            #region Db
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<SocialNetworkContext>(opt => opt.UseInMemoryDatabase("DBSocialNetwork"));
            }
            else
            {
                var connetionString = config.GetConnectionString("DefaultConnection");
               services.AddDbContext<SocialNetworkContext>(

                   (serviceProvider, opt) =>
                   {
                       opt.EnableSensitiveDataLogging();
                       opt.UseSqlServer(connetionString, m => m.MigrationsAssembly(typeof(SocialNetworkContext).Assembly.FullName));
                   },
                   contextLifetime: ServiceLifetime.Scoped,
                   optionsLifetime: ServiceLifetime.Scoped
               );
            }
            #endregion

            #region IOC
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReactionRepository, ReactionRepository>();
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<ICoordinateRepository, CoordinateRepository>();
            services.AddScoped<IMoveRepository, MoveRepository>();
            services.AddScoped<IGameSessionRepository, GameSessionRepository>();
            #endregion

        }
    }
}
