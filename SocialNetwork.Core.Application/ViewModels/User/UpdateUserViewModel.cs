
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Core.Application.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public required string Id { get; set; }

        [Required(ErrorMessage = "You must enter the name of user")]
        [DataType(DataType.Text)]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter the last name of user")]
        [DataType(DataType.Text)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "You must enter the email of user")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "You must enter the username of user")]
        [DataType(DataType.Text)]
        public required string UserName { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        public string? Phone { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? ProfileImageFile { get; set; }

        public string? ProfileImage { get; set; }
    }
}
