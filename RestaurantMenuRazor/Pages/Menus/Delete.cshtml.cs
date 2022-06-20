using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenuRazor.Pages.Menus
{

    public class DeleteModel : PageModel
    {
        private readonly RestaurantMenuRazor.Data.RestaurantMenuRazorContext _context;

        public DeleteModel(RestaurantMenuRazor.Data.RestaurantMenuRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            menu = await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);

            if (menu == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            menu = await _context.Menu.FindAsync(id);

            if (menu != null)
            {
                Cart.CartList.RemoveAll(x => x.ID == id);
                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

}
