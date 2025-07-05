
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Identity.Entities
{
    public class AppUser: IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ProfileImage { get; set; }
    }
}
