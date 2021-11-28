using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMVC.Models
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public string SearchTerm { get; set; }
    }
}
