using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class registerModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Register Model { get; set; }

        public registerModel(UserManager<IdentityUser>UserManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager; ;
            this.userManager = UserManager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        
        

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email,
                };

                var  result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {

                    //CreateRole("Admin");
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToPage("Index");
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Page();
        }



    }
}
