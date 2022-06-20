using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Data;
using RestaurantMenuRazor.Models;

namespace RestaurantMenuRazor.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly RestaurantMenuRazor.Data.RestaurantMenuRazorContext _context;

        public DetailsModel(RestaurantMenuRazor.Data.RestaurantMenuRazorContext context)
        {
            _context = context;
        }

        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);

            if (Menu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
