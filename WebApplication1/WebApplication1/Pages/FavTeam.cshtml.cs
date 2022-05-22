using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    public class FavTeamModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser user;
        public FavTeamModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
            //user = await _userManager.GetUserAsync(User);
        }
    }
}
