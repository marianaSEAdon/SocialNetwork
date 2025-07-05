using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Base.Enums;

namespace SocialNetwork.ViewComponents
{
    public class NotificationPendingCountViewComponent : ViewComponent
    {
        private readonly IFriendRequestService _friendRequestService;
     

        public NotificationPendingCountViewComponent(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var request = await _friendRequestService.GetAll();
            var notiCount = request.Where(p => p.ReceivingUserId == userId && p.Status == (int)FriendStatus.PENDING).Count();

            return View(notiCount);
        }
    }
}
