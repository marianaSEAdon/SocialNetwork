using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Coordinate: BaseEntity<int>
    {
        public override int Id { get; set; }
        public required int X { get; set; }
        public required int Y { get; set; }
        public required int Status { get; set; }
        public int BoardId { get; set; }
        public required Board Board { get; set; }
        public int? ShipId { get; set; } 
        public Ship? Ship { get; set; }
        public ICollection<Move>? Moves { get; set; }
    }
}
