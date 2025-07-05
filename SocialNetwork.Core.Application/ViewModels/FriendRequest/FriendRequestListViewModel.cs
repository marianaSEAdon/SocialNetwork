

using SocialNetwork.Core.Application.ViewModels.User;

namespace SocialNetwork.Core.Application.ViewModels.FriendRequest
{
    public class FriendRequestListViewModel
    {
        public List<UserViewModel>? PendingRequests { get; set; }
        public List<UserViewModel>? SentRequests { get; set; }
    }
}
