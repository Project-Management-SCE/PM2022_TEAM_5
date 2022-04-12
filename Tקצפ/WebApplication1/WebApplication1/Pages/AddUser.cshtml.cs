using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class AddUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        public List<string> RoleItems { get; set; }

        [BindProperty]
        public AddUser Model { get; set; }


        public AddUserModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            RoleItems = new List<string> { "Standard", "Vip", "Admin" };
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.UserName,
                    Email = Model.Email,
                };

                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    if(Model.Role.Equals("Admin"))
                        await userManager.AddToRoleAsync(user, "Vip");

                    await userManager.AddToRoleAsync(user, Model.Role);
                    return RedirectToPage("AdminPanel");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Page();
        }

    }
}
