using SocialNetwork.Core.Application.Dtos.Email;

namespace SocialNetwork.Core.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto emailRequestDto);
    }
}