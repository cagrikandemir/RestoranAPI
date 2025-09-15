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
    }
}
