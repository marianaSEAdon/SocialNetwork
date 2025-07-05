using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Dtos.Reaction;

namespace SocialNetwork.Core.Application.Dtos.Post
{
    public class PostDto: BaseDto<int>
    {
        public override int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Imagen { get; set; }
        public string? Video { get; set; }
        public required string UserId { get; set; }
        public ICollection<CommentDto>? Comments { get; set; }
        public ICollection<ReactionDto>? Reactions { get; set; }
    }
}
