using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class ChangeEmailModel : PageModel
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInMannager;

        [BindProperty]
        public ChangeEmail Model { get; set; }

        public ChangeEmailModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInMannager = signInManager;
        }

        public ChangeEmailModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;            
        }

        public void OnGet()
        {
        }

        public async Task<bool> updateUser(ChangeEmail model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return false;
            }

            if ((Model.UserName != null) && !Model.UserName.Equals(""))
                user.UserName = model.UserName;

            if ((Model.NewEmail != null) && !Model.NewEmail.Equals(""))
                user.Email = model.NewEmail;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return false;
            }
            await signInMannager.RefreshSignInAsync(user);
            return true;
        }

        public async Task<bool> updateUser2(ChangeEmail model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return false;
            }

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> OnPostAsync(ChangeEmail model)
        {
            if (ModelState.IsValid)
            {
                //var user = await userManager.GetUserAsync(User);
                //if (user == null)
                //{
                //    return Page();
                //}

                //if((Model.UserName != null) && !Model.UserName.Equals(""))
                //    user.UserName = model.UserName;

                //if((Model.NewEmail != null) && !Model.NewEmail.Equals(""))
                //    user.Email = model.NewEmail;

                //var result = await userManager.UpdateAsync(user);                
                //if (!result.Succeeded)
                //{
                //    foreach (var err in result.Errors)
                //    {
                //        ModelState.AddModelError("", err.Description);
                //    }
                //}
                //await signInMannager.RefreshSignInAsync(user);
                if (await updateUser(model))
                {
                    return RedirectToPage("Index");
                }
            }

            return Page();

        }
    }


   

}
