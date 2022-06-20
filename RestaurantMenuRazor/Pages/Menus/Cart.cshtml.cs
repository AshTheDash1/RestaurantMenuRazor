using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Data;
using RestaurantMenuRazor.Models;

namespace RestaurantMenuRazor.Pages.Menus
{
    public class CreateModel : PageModel
    {
        public List<Menu> CartList = Cart.CartList;
        private readonly RestaurantMenuRazor.Data.RestaurantMenuRazorContext _context;

        public CreateModel(RestaurantMenuRazor.Data.RestaurantMenuRazorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        [BindProperty]
        public Menu Menus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            _context.Menu.Add(Menus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
