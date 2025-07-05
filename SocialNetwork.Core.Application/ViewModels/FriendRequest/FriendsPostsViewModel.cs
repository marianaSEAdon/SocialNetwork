
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;

namespace SocialNetwork.Core.Application.ViewModels.FriendRequest
{
    public class FriendsPostsViewModel
    {
        public List<UserViewModel> Friends { get; set; } = new();
        public List<PostViewModel> Posts { get; set; } = new();
    }
}
