
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Domain.Entities
{
    public class GameSession : BaseEntity<int>
    {
        public override int Id { get ; set ; }
        public required bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string PlayerOneId {  get; set; }
        public required string PlayerTwoId { get; set; }
        public int PlayerOneBoardId { get; set; }
        public Board? PlayerOneBoard { get; set; }
        public int PlayerTwoBoardId { get; set; }
        public Board? PlayerTwoBoard { get; set; }
        public string? WinnerId { get; set; }
        public ICollection<Move>? Moves { get; set; }

    }
}
