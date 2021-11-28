using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodMVC.Data;
using FoodMVC.Models;

namespace FoodMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        // GET: Restaurants
        public IActionResult Index(string searchTerm)
        {
            RestaurantViewModel restaurantViewModel = new RestaurantViewModel
            {
                Restaurants = restaurantRepository.GetRestaurantsByName(searchTerm).ToList()
            };
            return View(restaurantViewModel);
        }

        // GET: Restaurants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id);
            }

            var restaurant = restaurantRepository.GetById(id.Value);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id.Value);
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantRepository.Add(restaurant);
                restaurantRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id);
            }

            var restaurant = restaurantRepository.GetById(id.Value);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id.Value);
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    restaurantRepository.Update(restaurant);
                    restaurantRepository.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        Response.StatusCode = 404;
                        return View("RestaurantNotFound", restaurant.Id);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id); ;
            }

            var restaurant = restaurantRepository.GetById(id.Value);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id.Value);
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var restaurant = restaurantRepository.GetById(id.Value);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return View("RestaurantNotFound", id.Value);
            }
            restaurantRepository.Delete(id.Value);
            restaurantRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return restaurantRepository.GetById(id) != null;
        }
    }
}
