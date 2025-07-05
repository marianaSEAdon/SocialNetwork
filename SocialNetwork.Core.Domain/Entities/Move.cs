

using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Move: BaseEntity<int>
    {
        public override int Id { get; set; }
        public required string PlayerId { get; set; }
        public required int CoordinateId { get; set; }
        public Coordinate? Coordinate { get; set; }
        public bool IsHit { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int GameSeccionId { get; set; }
        public GameSession? GameSession { get; set; }
    }
}
