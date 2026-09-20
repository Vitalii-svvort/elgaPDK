using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MeetingProtocols.Pages
{
    [AllowAnonymous] // Разрешаем доступ без авторизации
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public string Email { get; set; } = "";
        [BindProperty]
        public string Password { get; set; } = "";

        public string Message { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _signInManager.PasswordSignInAsync(Email, Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToPage("/Dashboard");
            }
            else
            {
                Message = "Неверный логин или пароль";
                return Page();
            }
        }
    }
}
