using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.Post;
using SocialNetwork.Core.Application.Dtos.Reaction;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.Reaction;
using SocialNetwork.Helpers;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly IReactionService _reactionService;
        private readonly IPostService _postService;
        private readonly IAccountServiceForWebApp _accountServiceForWebApp;
        private readonly IMapper _mapper;
        public HomeController(IPostService postService,  IMapper mapper, IAccountServiceForWebApp accountServiceForWebApp, IReactionService reactionService)
        {
            _postService = postService;
            _mapper = mapper;
            _accountServiceForWebApp = accountServiceForWebApp;
            _reactionService = reactionService;
       
        }

        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(id))
            {
                return Unauthorized(); 
            }
            var user = await _accountServiceForWebApp.GetUserById(id);
            var users = await _accountServiceForWebApp.GetAllUser();
            var allpost = await _postService.GetAllWithInclude();
            var post = allpost.Where(u => u.UserId == id).ToList();
            
            //List<PostViewModel> dto = _mapper.Map<List<PostViewModel>>(post);
            List<PostViewModel> dto = post.Select(p => new PostViewModel
            {
                Id = p.Id,
                Text = p.Text,
                UserId = p.UserId,
                Username = user.UserName,
                ProfileImage = user.ProfileImage,
                CreatedAt = p.CreatedAt,
                Imagen = p.Imagen,
                Video = p.Video,
                Comments = p.Comments?.Select(c =>
                {
                    var commentUser = users.FirstOrDefault(u => u.Id == c.UserId);

                    return new CommentViewModel
                    {
                        Id = c.Id,
                        Text = c.Text,
                        UserId = c.UserId,
                        Username = commentUser?.UserName ?? "Unknown",
                        ProfileImage = commentUser?.ProfileImage,
                        CreatedAt = c.CreatedAt,
                        PostId = c.PostId,
                        RepliedCommentId = c.RepliedCommentId,

                        Replies = p.Comments
                            .Where(r => r.RepliedCommentId == c.Id)
                            .Select(r =>
                            {
                                var replyUser = users.FirstOrDefault(u => u.Id == r.UserId);
                                return new CommentViewModel
                                {
                                    Id = r.Id,
                                    Text = r.Text,
                                    UserId = r.UserId,
                                    Username = replyUser?.UserName ?? "Unknown",
                                    ProfileImage = replyUser?.ProfileImage,
                                    CreatedAt = r.CreatedAt,
                                    PostId = r.PostId,
                                    RepliedCommentId = r.RepliedCommentId
                                };
                            }).ToList()
                    };

                }).ToList() ?? [],
                Reactions = _mapper.Map<ICollection<ReactionViewModel>>(p.Reactions)
            }).ToList();

            return View(dto);
        }
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(new CreatePostViewModel()
            {
                Text = "",
                UserId = userId ?? "",
                Imagen = null,
                Video = "",
                CreatedAt = DateTime.Now, 
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? "";

            PostDto dto = _mapper.Map<PostDto>(vm);
            if (vm.Imagen != null)
            {
                dto.Imagen = FileManager.Upload(vm.Imagen, dto.Id.ToString(), "Post");
            }
            await _postService.AddAsync(dto);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _postService.GetById(id);
            return View(new EditPostViewModel()
            {
                Id = dto.Id,
                Text = dto.Text,
                UserId = dto.UserId,
                CurrentImage = dto.Imagen,
                Video = dto.Video,
                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            PostDto dto = _mapper.Map<PostDto>(vm);

            dto.Imagen = vm.CurrentImage;
            dto.Video = vm.Video;
            await _postService.UpdateAsync(dto, dto.Id);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        public async Task<IActionResult> Reaction(int postId, int type)
        {
            var allreaction = await _reactionService.GetAll();
            var existing = allreaction.FirstOrDefault(r => r.PostId == postId && r.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (existing != null)
            {
                existing.ReactionType = type;
                await _reactionService.UpdateAsync(existing, existing.Id);
            }
            else
            {
                var reaction = new ReactionDto
                {
                    PostId = postId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                    ReactionType = type
                };

                await _reactionService.AddAsync(reaction);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var dto = await _postService.GetById(id);
            if (dto == null)
            {
                return RedirectToRoute(new { controller = "Asset", action = "Index" });
            }
            DeletePostViewModel vm = new() { Id = dto.Id };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _postService.DeleteAsync(vm.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
