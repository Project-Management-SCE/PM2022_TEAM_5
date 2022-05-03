using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin,Vip,Standard")]
    public class UserPanelModel : PageModel
    {

        public byte[] profilePic { get; set; }
        public void OnGet()
        {
            var sessionUser = JsonConvert.DeserializeObject<ApplicationUser>(HttpContext.Session.GetString("SessionUser"));
            profilePic = sessionUser.ProfilePic;
        }
    }
}
