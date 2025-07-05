
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.Dtos.User
{
    public class LoginResponseDto: BaseDto<string>
    {
        public override required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public bool IsVerified { get; set; }
        public bool HasError { get; set; }
        public required List<string> Errors { get; set; }


    }
}
