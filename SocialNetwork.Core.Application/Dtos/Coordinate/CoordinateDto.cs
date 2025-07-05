using SocialNetwork.Core.Application.Dtos.Board;
using SocialNetwork.Core.Application.Dtos.Move;
using SocialNetwork.Core.Application.Dtos.Ship;
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.Dtos.Coordinate
{
    public class CoordinateDto: BaseEntity<int>
    {
        public override int Id { get; set; }
        public required int X { get; set; }
        public required int Y { get; set; }
        public required int Status { get; set; }
        public int BoardId { get; set; }
        public required BoardDto Board { get; set; }
        public int? ShipId { get; set; }
        public ShipDto? Ship { get; set; }
        public ICollection<MoveDto>? Moves { get; set; }
    }
}
