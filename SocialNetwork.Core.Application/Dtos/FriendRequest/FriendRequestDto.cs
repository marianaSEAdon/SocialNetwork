namespace SocialNetwork.Core.Application.Dtos.FriendRequest
{
    public class FriendRequestDto: BaseDto<int>
    {
        public override int Id { get; set; }
        public required string RequestingUserId { get; set; }
        public required string ReceivingUserId { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? ResponseDate { get; set; }
        public required int Status { get; set; }
    }
}
