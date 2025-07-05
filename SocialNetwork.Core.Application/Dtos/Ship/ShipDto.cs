using SocialNetwork.Core.Application.Dtos.Board;
using SocialNetwork.Core.Application.Dtos.Coordinate;

namespace SocialNetwork.Core.Application.Dtos.Ship
{
    public class ShipDto: BaseDto<int>
    {
        public override int Id { get; set; }
        public int Size { get; set; }
        public char Value { get; set; }
        public int ShipDirection { get; set; }
        public ICollection<CoordinateDto>? Coordinates { get; set; }
        public required int BoardId { get; set; }
        public BoardDto? Board { get; set; }
    }
}
