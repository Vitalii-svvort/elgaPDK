using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeetingProtocols.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string Email { get; set; } = "";
        [BindProperty]
        public string Password { get; set; } = "";

        public string Message { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            var user = new IdentityUser { UserName = Email, Email = Email };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                // Пользователь создан, можно сразу логинить или перенаправить на вход
                Message = "Регистрация успешна! Теперь войдите.";
                return Page();
            }
            else
            {
                Message = "Ошибка регистрации: " + string.Join(", ", result.Errors.Select(e => e.Description));
                return Page();
            }
        }
    }
}
