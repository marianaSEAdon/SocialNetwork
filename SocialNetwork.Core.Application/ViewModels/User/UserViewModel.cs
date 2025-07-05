using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Core.Domain.Base;

namespace SocialNetwork.Core.Application.ViewModels.User
{
    public class UserViewModel: BaseViewModel<string>
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
