
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Comment: BaseEntity<int>
    {
        public override required int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public int? RepliedCommentId { get; set; }
        public Post? Post { get; set; }
        public Comment? RepliedComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = [];
    }
}
