
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Reaction;

namespace SocialNetwork.Core.Application.ViewModels.Post
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Upload)]
        public IFormFile? Imagen { get; set; }
        public string? CurrentImage { get; set; }
        public string? Video { get; set; }
        public required string UserId { get; set; }
        public ICollection<CommentViewModel>? Comments { get; set; }
        public ICollection<ReactionViewModel>? Reactions { get; set; }
    }
}
