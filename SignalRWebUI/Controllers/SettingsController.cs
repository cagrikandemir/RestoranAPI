using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new();
            userEditDto.Name = values.Name;
            userEditDto.Surname = values.Surname;
            userEditDto.Mail = values.Email;
            userEditDto.Password = values.PasswordHash;
            userEditDto.Username = values.UserName;
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult>Index(UserEditDto userEditDto)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Name = userEditDto.Name;
            values.Surname = userEditDto.Surname;
            values.Email = userEditDto.Mail;
            values.UserName = userEditDto.Username;
            values.PasswordHash=_userManager.PasswordHasher.HashPassword(values,userEditDto.Password);
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
