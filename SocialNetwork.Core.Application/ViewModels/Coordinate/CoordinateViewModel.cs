using SocialNetwork.Core.Application.ViewModels.Board;
using SocialNetwork.Core.Application.ViewModels.Move;
using SocialNetwork.Core.Application.ViewModels.Ship;

namespace SocialNetwork.Core.Application.ViewModels.Coordinate
{
    public class CoordinateViewModel: BaseViewModel<int>
    {
        public override int Id { get; set; }
        public required int X { get; set; }
        public required int Y { get; set; }
        public required int Status { get; set; }
        public int BoardId { get; set; }
        public required BoardViewModel Board { get; set; }
        public int? ShipId { get; set; }
        public ShipViewModel? Ship { get; set; }
        public ICollection<MoveViewModel>? Moves { get; set; }
    }
}
