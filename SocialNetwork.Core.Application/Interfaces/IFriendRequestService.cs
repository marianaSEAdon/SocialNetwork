
using SocialNetwork.Core.Application.Dtos.FriendRequest;


namespace SocialNetwork.Core.Application.Interfaces
{
    public interface IFriendRequestService : IGenericService<FriendRequestDto>
    {
        Task<FriendRequestDto?> GetBetweenUsersAsync(string userA, string userB);
    }
}
