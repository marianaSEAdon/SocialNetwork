using SocialNetwork.Core.Application.Dtos.Coordinate;
using SocialNetwork.Core.Application.Dtos.Ship;

namespace SocialNetwork.Core.Application.Dtos.Board
{
    public class BoardDto: BaseDto<int>
    {
        public override int Id { get; set; }

        public const int Size = 12;
        public required string UserId { get; set; }
        public ICollection<CoordinateDto>? Coordinates { get; set; }
        public ICollection<ShipDto>? Ships { get; set; }
    }
}
