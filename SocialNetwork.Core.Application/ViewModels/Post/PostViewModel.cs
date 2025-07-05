

using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Reaction;

namespace SocialNetwork.Core.Application.ViewModels.Post
{
    public class PostViewModel: BaseViewModel<int>
    {
        public override int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Imagen { get; set; }
        public string? Video { get; set; }
        public required string UserId { get; set; }
        public ICollection<CommentViewModel>? Comments { get; set; }
        public ICollection<ReactionViewModel>? Reactions { get; set; }
    }
}
