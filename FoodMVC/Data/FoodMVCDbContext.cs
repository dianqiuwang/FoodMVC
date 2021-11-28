using FoodMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMVC.Data
{
    public class FoodMVCDbContext : DbContext
    {
        public FoodMVCDbContext(DbContextOptions<FoodMVCDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
