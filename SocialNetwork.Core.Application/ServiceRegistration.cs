
using System.ComponentModel.Design;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.Services;

namespace SocialNetwork.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayerIoc(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region IOC
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IFriendRequestService, FriendRequestService>();
            services.AddScoped<IShipService, ShipService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICoordinateService, CoordinateService>();
            services.AddScoped<IGameSessionService, GameSessionService>();
            services.AddScoped<IMoveService, MoveService>();
            #endregion
        }

    }


}
