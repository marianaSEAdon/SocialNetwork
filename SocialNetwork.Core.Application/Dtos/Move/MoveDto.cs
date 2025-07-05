
using SocialNetwork.Core.Application.Dtos.Coordinate;
using SocialNetwork.Core.Application.Dtos.GameSession;
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.Dtos.Move
{
    public class MoveDto: BaseEntity<int>
    {
        public override int Id { get; set; }
        public required string PlayerId { get; set; }
        public required int CoordinateId { get; set; }
        public CoordinateDto? Coordinate { get; set; }
        public bool IsHit { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int GameSeccionId { get; set; }
        public GameSessionDto? GameSession { get; set; }
    }
}
