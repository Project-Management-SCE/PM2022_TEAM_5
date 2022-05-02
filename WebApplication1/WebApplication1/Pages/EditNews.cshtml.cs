using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class EditNewsModel : PageModel
    {
        [BindProperty]
        public EditNews model { get; set; }
        public List<News> db; 

        public string current;
        public void OnGet()
        {
            //db = (new NewsContext()).ToList<News>();
            //if(db.Count>0)
            //    current = ((News)(db[0].News)).text;
    }

        public EditNewsModel()
        {

        }
    }
}
