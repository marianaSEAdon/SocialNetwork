

namespace SocialNetwork.Core.Application.Dtos.User
{
    public class UserDto: BaseDto<string>
    {
        public override required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImage { get; set; }
        public bool? IsVerified { get; set; }
    }
}
