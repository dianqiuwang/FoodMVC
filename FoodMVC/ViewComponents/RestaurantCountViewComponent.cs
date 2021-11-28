using FoodMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMVC.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantCountViewComponent(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantRepository.GetCountOfRestaurants();
            return View(count);
        }
    }
}
