
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Dtos.Post;

namespace SocialNetwork.Core.Application.ViewModels.Comment
{
    public class CommentViewModel: BaseViewModel<int>
    {
        public override int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required int PostId { get; set; }
        public required string UserId { get; set; }
        public int? RepliedCommentId { get; set; }
        public PostDto? Post { get; set; }
        public CommentViewModel? RepliedComment { get; set; }
        public ICollection<CommentViewModel> Replies { get; set; } = [];
    }
}
