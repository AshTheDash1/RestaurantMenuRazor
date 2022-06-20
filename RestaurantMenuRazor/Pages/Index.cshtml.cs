using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantMenuRazor.Data.RestaurantMenuRazorContext _context;
        public IndexModel(RestaurantMenuRazor.Data.RestaurantMenuRazorContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MenuCategory { get; set; }

        public IActionResult OnGet()
        {
            string url = "/Menus";

            return Redirect(url);
        }
    }
}
