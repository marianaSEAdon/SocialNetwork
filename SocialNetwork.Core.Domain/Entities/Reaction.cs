
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Reaction: BaseEntity<int>
    {
        public override required int Id { get; set; }
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public required int ReactionType { get; set; }
        public Post? Post { get; set; }
    }
}
