
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Board : BaseEntity<int>
    {
        public override int Id { get; set; }
        
        public const int Size = 12;
        public  required string UserId { get; set; }
        public ICollection<Coordinate>? Coordinates { get; set; }
        public ICollection<Ship>? Ships { get; set; }
    }
}
