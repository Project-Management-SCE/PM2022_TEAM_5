using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Login Model { get; set; }
        public void OnGet()
        {
        }
        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            var user = await userManager.FindByNameAsync(Model.EmailOrUserName);

            if (Model.EmailOrUserName.Contains("@"))
                user = await userManager.FindByEmailAsync(Model.EmailOrUserName);            
            if (user == null)
            {
                return Page();
            }
            if (ModelState.IsValid)
            {
                var identity = await signInManager.PasswordSignInAsync(user.UserName, Model.Password, Model.RememberMe, false);
                if (identity.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Email or Password incorrect");
            }

            return Page();
        }
    }
}
