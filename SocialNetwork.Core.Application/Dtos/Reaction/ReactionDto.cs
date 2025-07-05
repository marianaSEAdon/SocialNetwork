
using SocialNetwork.Core.Application.Dtos.Post;

namespace SocialNetwork.Core.Application.Dtos.Reaction
{
    public class ReactionDto: BaseDto<int>
    {
        public override int Id { get; set; }
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public required int ReactionType { get; set; }
        public PostDto? Post { get; set; }
    }
}
