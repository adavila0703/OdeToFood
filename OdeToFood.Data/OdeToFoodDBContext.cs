using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options)
            : base(options)
        {

        }
        
    }
}
