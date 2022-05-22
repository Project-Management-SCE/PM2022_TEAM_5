using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public EmailAttachmentModel emailAttachmentModel { get; set; }
        public ContactUsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;     
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(EmailAttachmentModel model)
        {
            


            return RedirectToPage("Index");
        }

    }
}
