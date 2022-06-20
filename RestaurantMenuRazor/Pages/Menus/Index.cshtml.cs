using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuRazor.Pages.Menus
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
        [BindProperty]
        public Menu MenuCart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IQueryable<string> genreQuery = from m in _context.Menu
                                            orderby m.Category
                                            select m.Category;

            var MenuItemsList = from m in _context.Menu
                                select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                MenuItemsList = MenuItemsList.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MenuCategory))
            {
                MenuItemsList = MenuItemsList.Where(x => x.Category == MenuCategory);
            }
            Category = new SelectList(await genreQuery.Distinct().ToListAsync());
            Menu = await MenuItemsList.ToListAsync();

            MenuCart = await _context.Menu.FirstOrDefaultAsync(c => c.ID == id);

            if (MenuCart != null)
            {
                Cart.CartList.Add(MenuCart);
            }


            return Page();
        }
    }
}
