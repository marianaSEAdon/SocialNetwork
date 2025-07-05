using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.Post;
using SocialNetwork.Core.Application.Dtos.Reaction;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.ViewModels.Post;
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
            var allpost = await _postService.GetAllWithInclude();
            var post = allpost.Where(u => u.UserId == id).ToList();
            
            List<PostViewModel> dto = _mapper.Map<List<PostViewModel>>(post);

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
