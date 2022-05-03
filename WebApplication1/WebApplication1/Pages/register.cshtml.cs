using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class registerModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHostingEnvironment _env;

        [BindProperty]
        public Register Model { get; set; }

        public registerModel(IHostingEnvironment env,UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager; ;
            this.userManager = UserManager;
            this.signInManager = signInManager;
            this._env = env;
        }
        public void OnGet()
        {
        }

        
        

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {


                string path = _env.WebRootPath + "\\img\\default_pic.png";
                byte[] photo = System.IO.File.ReadAllBytes(path);

                var user = new ApplicationUser()
                {
                    UserName = Model.UserName,
                    Email = Model.Email,
                    ProfilePic = photo,
                };

                var  result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    var role = "Standard";
                    if (Model.Role)
                    {
                        role = "Vip";
                    }
                    
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, role);
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
