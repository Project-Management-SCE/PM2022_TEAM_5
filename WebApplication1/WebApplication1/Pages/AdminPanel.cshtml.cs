using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelModel : PageModel
    {
        [BindProperty]
        public Role Model { get; set; }
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminPanelModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public void OnGet()
        {
        }

        
        public async Task<IActionResult> OnPostCreateRoleAsync()
        {
            string r = Request.Form["role"];
            var isExist = await roleManager.RoleExistsAsync(r);
            if (!isExist)
            {
                var res = await roleManager.CreateAsync(new IdentityRole(r));
               
            }
            return RedirectToPage();
        }
    }
}
