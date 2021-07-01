using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyVersion.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }

        //remember you always need to add a constructor in your html.cs file
        public DetailModel(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }

        //public void OnGet(int RestaurantID)
        //{
        //    //System.InvalidOperationException
        //    try
        //    {
        //        Message = "Welcome";
        //        Restaurant = _restaurantData.GetSingleRestaurant(RestaurantID).Single();
        //    }
        //    catch (System.InvalidOperationException)
        //    {
        //        Message = "This is not a valid restaurant.";
        //    }

        //}

        public IActionResult OnGet(int RestaurantID)
        {
            Restaurant = _restaurantData.GetSingleRestaurant_2(RestaurantID);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
