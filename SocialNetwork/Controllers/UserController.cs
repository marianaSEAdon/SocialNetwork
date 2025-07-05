using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.User;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Helpers;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAccountServiceForWebApp _accountServiceForWebApp;

        public UserController(IAccountServiceForWebApp accountServiceForWebApp)
        {
            _accountServiceForWebApp = accountServiceForWebApp;
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.EditMode = true;
            var dto = await _accountServiceForWebApp.GetUserById(id);


            if (dto == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            UpdateUserViewModel vm = new()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                Email = dto.Email,
                UserName = dto.UserName,
                LastName = dto.LastName,
                Password = "",
                Phone = dto.Phone,
                ProfileImage = dto.ProfileImage
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View(vm);
            }

            string origin = Request?.Headers?.Origin.ToString() ?? string.Empty;

            SaveUserDto dto = new()
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                Email = vm.Email,
                UserName = vm.UserName,
                LastName = vm.LastName,
                Password = vm.Password ?? "",
                Phone = vm.Phone,
                ProfileImage = vm.ProfileImage

            };

            var currentDto = await _accountServiceForWebApp.GetUserById(vm.Id);
            string? currentImagePath = "";

            if (currentDto != null)
            {
                currentImagePath = currentDto.ProfileImage;
            }

            dto.ProfileImage = FileManager.Upload(vm.ProfileImageFile, dto.Id, "Users", true, currentImagePath ?? "");
            var returnUser = await _accountServiceForWebApp.EditUser(dto, origin);
            if (returnUser.HasError)
            {
                ViewBag.EditMode = true;
                ViewBag.HasError = true;
                ViewBag.Errors = returnUser.Errors;
                return View(vm);
            }

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }



    }



}
