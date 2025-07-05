
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Ship: BaseEntity<int>
    {
        public override int Id { get; set; }
        public int Size { get; set; }
        public char Value { get; set; }
        public int ShipDirection { get; set; }
        public ICollection<Coordinate>? Coordinates { get; set; }
        public required int BoardId { get; set; }
        public Board? Board { get; set; }
    }
}
