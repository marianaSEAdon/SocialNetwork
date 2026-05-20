using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.FriendRequest;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.FriendRequest;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.Reaction;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Base.Enums;
namespace SocialNetwork.Controllers
{
    [Authorize]
    public class FriendRequestController : Controller
    {
        private readonly IFriendRequestService _friendRequestService;
        private readonly IAccountServiceForWebApp _accountServiceForWebApp;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public FriendRequestController(IFriendRequestService friendRequestService, IMapper mapper, IAccountServiceForWebApp accountServiceForWebApp, IPostService postService)
        {
            _friendRequestService = friendRequestService;
            _mapper = mapper;
            _accountServiceForWebApp = accountServiceForWebApp;
            _postService = postService;
        }

       

        //Perfecto
        public async Task<IActionResult> FriendPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allRequests = await _friendRequestService.GetAll();

            var friendIds = allRequests
                .Where(fr => fr.Status == (int)FriendStatus.ACCEPTED && (fr.RequestingUserId == userId || fr.ReceivingUserId == userId))
                .Select(fr => fr.RequestingUserId == userId ? fr.ReceivingUserId : fr.RequestingUserId)
                .Distinct()
                .ToList();

            var friendDtos = await _accountServiceForWebApp.GetUsersByIdsAsync(friendIds);

           

            var friendViewModels = friendDtos.Select(friend => new UserViewModel
            {
                Id = friend.Id,
                FirstName = friend.FirstName,
                LastName = friend.LastName,
                Email = friend.Email,
                UserName = friend.UserName,
                ProfileImage = friend.ProfileImage
            }).ToList();

            var allPosts = await _postService.GetAllWithInclude();
            var posts = allPosts.Where(p => friendDtos.Select(f => f.Id).Contains(p.UserId)).ToList();


            //var postViewModels = _mapper.Map<List<PostViewModel>>(posts);
            var users = await _accountServiceForWebApp.GetAllUser();

            var postViewModels = posts.Select(p =>
            {
                var postUser = users.FirstOrDefault(u => u.Id == p.UserId);

                return new PostViewModel
                {
                    Id = p.Id,
                    Text = p.Text,
                    UserId = p.UserId,

                    Username = postUser?.UserName ?? "Unknown",
                    ProfileImage = postUser?.ProfileImage,

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
                            { var replyUser = users.FirstOrDefault(u => u.Id == r.UserId);
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
                };

            }).ToList();

            var model = new FriendsPostsViewModel
            {
                Friends = friendViewModels,
                Posts = postViewModels
            };

            return View(model);
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var allUsers = await _accountServiceForWebApp.GetAllUser();

            var allRequests = await _friendRequestService.GetAll();

            var friendIds = allRequests
                .Where(r => r.Status == (int)FriendStatus.ACCEPTED &&
                       (r.RequestingUserId == userId || r.ReceivingUserId == userId))
                .Select(r => r.RequestingUserId == userId ? r.ReceivingUserId : r.RequestingUserId)
                .ToList();

            var filteredUsers = allUsers
                .Where(u => u.Id != userId && !friendIds.Contains(u.Id))
                .ToList();

            List<UserViewModel> vm = _mapper.Map<List<UserViewModel>>(filteredUsers);

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Index(string receivingUserId)
        {

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var exist = await _friendRequestService.GetBetweenUsersAsync(user, receivingUserId);
            
            if (exist != null && exist.Status == (int)FriendStatus.PENDING)
            {
                TempData["Error"] = "You have sent a request.";
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (user == receivingUserId)
            {
                TempData["Error"] = "You can't sent you a request";
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var dto = new FriendRequestDto
            {
                ReceivingUserId = receivingUserId,
                RequestDate = DateTime.UtcNow,
                ResponseDate = null,
                RequestingUserId = user,
                Status = (int)FriendStatus.PENDING
            };

            await _friendRequestService.AddAsync(dto);
            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }


        
        //Lets check
        public async Task<IActionResult> Pending()
        {
            var alluser = await _accountServiceForWebApp.GetAllUser();
            var requests = await _friendRequestService.GetAll();

            var pendingRequestingUserIds = requests
                .Where(r => r.Status == (int)FriendStatus.PENDING && r.ReceivingUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Select(r => r.RequestingUserId)
                .Distinct()
                .ToList();


            var sendersRequestingUserIds = requests
                .Where(r => r.Status == (int)FriendStatus.PENDING && r.RequestingUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Select(r => r.ReceivingUserId)
                .Distinct()
                .ToList();

            var pendingfilteredUsers = alluser.Where(u => pendingRequestingUserIds.Contains(u.Id)).ToList();
            var senderfilteredUsers = alluser.Where(u => sendersRequestingUserIds.Contains(u.Id)).ToList();


            var usersVMP = _mapper.Map<List<UserViewModel>>(pendingfilteredUsers);
            var usersVMS = _mapper.Map<List<UserViewModel>>(senderfilteredUsers);

            var vm = new FriendRequestListViewModel
            {
                PendingRequests = usersVMP,
                SentRequests = usersVMS
            };

            return View(vm);
        }

        public async Task<IActionResult> Accept(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "FriendRequest", action = "Index" });
            }

            var dto = await _friendRequestService.GetById(id);
            if (dto == null)
            {
                return RedirectToRoute(new { controller = "FriendRequest", action = "Index" });
            }
            UpdateFriendRequestViewModel vm = new() 
            { 
                Id = dto.Id,
                ReceivingUserId = dto.ReceivingUserId,
                RequestingUserId = dto.RequestingUserId,
                RequestDate = dto.RequestDate,
                ResponseDate = dto.ResponseDate,
                Status = dto.Status

            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(string userId)
        {
            try
            {

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Pending");
                }

                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

     
                var allRequests = await _friendRequestService.GetAll();
                var request = allRequests.FirstOrDefault(r =>
                    r.RequestingUserId == userId &&
                    r.ReceivingUserId == currentUserId &&
                    r.Status == (int)FriendStatus.PENDING);

                if (request == null)
                {
                    return RedirectToAction("Pending");
                }

                var dto = new FriendRequestDto
                {
                    Id = request.Id,
                    RequestingUserId = request.RequestingUserId,
                    ReceivingUserId = request.ReceivingUserId,
                    RequestDate = request.RequestDate,
                    ResponseDate = DateTime.UtcNow,
                    Status = (int)FriendStatus.ACCEPTED
                };

                var success = await _friendRequestService.UpdateAsync(dto, dto.Id);

               
                return RedirectToAction("Pending");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error inesperado";
                return RedirectToAction("Pending");
            }
        }

        public async Task<IActionResult> Reject(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "FriendRequest", action = "Index" });
            }

            var dto = await _friendRequestService.GetById(id);
            if (dto == null)
            {
                return RedirectToRoute(new { controller = "FriendRequest", action = "Index" });
            }
            UpdateFriendRequestViewModel vm = new()
            {
                Id = dto.Id,
                ReceivingUserId = dto.ReceivingUserId,
                RequestingUserId = dto.RequestingUserId,
                RequestDate = dto.RequestDate,
                ResponseDate = dto.ResponseDate,
                Status = dto.Status

            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Reject(string userId)
        {
            try
            {

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Pending");
                }

                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                var allRequests = await _friendRequestService.GetAll();
                var request = allRequests.FirstOrDefault(r =>
                    r.RequestingUserId == userId &&
                    r.ReceivingUserId == currentUserId &&
                    r.Status == (int)FriendStatus.PENDING);

                if (request == null)
                {
                    return RedirectToAction("Pending");
                }

                var dto = new FriendRequestDto
                {
                    Id = request.Id,
                    RequestingUserId = request.RequestingUserId,
                    ReceivingUserId = request.ReceivingUserId,
                    RequestDate = request.RequestDate,
                    ResponseDate = DateTime.UtcNow,
                    Status = (int)FriendStatus.REJECTED
                };

                var success = await _friendRequestService.UpdateAsync(dto, dto.Id);


                return RedirectToAction("Pending");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Pending");
            }
        }


    }
}
