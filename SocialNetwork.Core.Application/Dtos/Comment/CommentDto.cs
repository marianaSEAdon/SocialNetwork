

using SocialNetwork.Core.Application.Dtos.Post;

namespace SocialNetwork.Core.Application.Dtos.Comment
{
    public class CommentDto: BaseDto<int>
    {
        public override int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public int? RepliedCommentId { get; set; }
        public PostDto? Post { get; set; }
        public CommentDto? RepliedComment { get; set; }
        public ICollection<CommentDto> Replies { get; set; } = [];
    }
}
