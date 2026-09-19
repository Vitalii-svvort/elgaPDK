namespace MeetingProtocols.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

[Authorize] // Доступ только авторизованным
public class DashboardModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public DashboardModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public string DisplayName { get; set; } = string.Empty;

    public async Task OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            // Для простоты показываем UserName (логин). Если хочешь отдельное поле «Имя» — скажи, докрутим.
            DisplayName = user.UserName;
        }
    }
}
