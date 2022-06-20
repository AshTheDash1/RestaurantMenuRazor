using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuRazor.Models;

namespace RestaurantMenuRazor.Data
{
    public class RestaurantMenuRazorContext : DbContext
    {
        public RestaurantMenuRazorContext (DbContextOptions<RestaurantMenuRazorContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantMenuRazor.Models.Menu> Menu { get; set; }
    }
}
