

using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Post: BaseEntity<int> 
    {
        public override int Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Imagen { get; set; }
        public string? Video { get; set; }
        public required string UserId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
    }
}
