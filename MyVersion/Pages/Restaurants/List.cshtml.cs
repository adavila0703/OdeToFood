using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyVersion.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData _restaurantData;


        public IEnumerable<Restaurant> Restaurants { get; set; }
        public List<string> Test { get; set; }

        public string Message { get; set; }
        //Bind a property to allow input and output
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData _restaurantData)
        {
            this.config = config;
            this._restaurantData = _restaurantData;
        }
        public void OnGet()
        {
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);

        }

        //My version, wrote before course example
        public IActionResult OnPost(int RestaurantID, string Delete)
        {
            if (bool.Parse(Delete) == true)
            {
                _restaurantData.Delete(RestaurantID);
                _restaurantData.Commit();
                Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
                return Page();
            }
            return Page();
        }
    }
}