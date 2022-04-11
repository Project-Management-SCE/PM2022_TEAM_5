using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class UserPanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
