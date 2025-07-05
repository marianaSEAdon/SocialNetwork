using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.ViewModels.Reaction
{
    public class ReactionViewModel: BaseEntity<int>
    {
        public override int Id { get; set; }
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public required int ReactionType { get; set; }
        public PostViewModel? Post { get; set; }
    }
}
