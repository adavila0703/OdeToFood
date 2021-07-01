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
    public class AddNewModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public AddNewModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this._restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
        public IActionResult OnPost()
        {
            //_restaurantData.AddNew(Restaurant.Name, Restaurant.Cuisine, Restaurant.Location);

            _restaurantData.Add(Restaurant);
            _restaurantData.Commit();
            return RedirectToPage("./List");
        }
    }
}
