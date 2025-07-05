using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.Comment;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.ViewModels.Comment;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService, IMapper mapper)
        {

            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentViewModel vm)
        {
            var dto = new CommentDto
            {
                Id = vm.Id,
                Text = vm.Text,
                PostId = vm.PostId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                CreatedAt = DateTime.UtcNow,
                RepliedCommentId = vm.RepliedCommentId,

            };

            await _commentService.AddAsync(dto);
            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
    }
}
