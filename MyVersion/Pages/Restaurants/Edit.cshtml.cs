using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyVersion.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }


        //helps build an html select
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this._restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int RestaurantID, string Delete)
        {
            Restaurant = _restaurantData.GetSingleRestaurant_2(RestaurantID);
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //if all the model binding passes with no errors look at OdeToFood.Core.Restaurant.cs
            if (ModelState.IsValid)
            {
                _restaurantData.Update(Restaurant);
                _restaurantData.Commit();
                return RedirectToPage("./List");

                //This is the how the course redirects to a specific page with data like Django
                //return RedirectToPage("./Details", new { RestaurantID = Restaurant.id });
            }
            else
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
        }
    }
}
