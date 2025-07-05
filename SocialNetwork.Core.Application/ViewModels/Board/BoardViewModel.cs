using SocialNetwork.Core.Application.ViewModels.Coordinate;
using SocialNetwork.Core.Application.ViewModels.Ship;

namespace SocialNetwork.Core.Application.ViewModels.Board
{
    public class BoardViewModel: BaseViewModel<int>
    {
        public override int Id { get; set; }

        public const int Size = 12;
        public required string UserId { get; set; }
        public ICollection<CoordinateViewModel>? Coordinates { get; set; }
        public ICollection<ShipViewModel>? Ships { get; set; }
    }
}
