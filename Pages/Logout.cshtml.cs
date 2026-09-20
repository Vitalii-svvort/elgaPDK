using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeetingProtocols.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            SignOutAsync();
            return RedirectToPage("/Login");
        }
    }
}
