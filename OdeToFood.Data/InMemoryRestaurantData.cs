using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="Chipolte", Location="Chicago", Cuisine=CuisineType.Meixcan},
                new Restaurant {Id=2, Name="Italiano", Location="Chicago", Cuisine=CuisineType.Italian},
                new Restaurant {Id=3, Name="Indians Palace", Location="Chicago", Cuisine=CuisineType.Indian}
            };
        }

        //My version, wrote before course example
        public void RemoveRest(int id)
        {
            var query = restaurants.Where(r => r.Id == id).Single();
            restaurants.Remove(query);
        }

        //My version, wrote before course example
        public void EditRest(int id, string name, CuisineType cuisine, string location)
        {
            var query = restaurants.Where(r => r.Id == id).Single();
            var query2 = from rest in restaurants
                         where rest.Id == id
                         select rest;

            query.Name = name;
            query.Location = location;
            query.Cuisine = cuisine;
        }
        //My version, wrote before course example
        public void AddNew(string name, CuisineType cuisine, string location)
        {
            var newRest = new Restaurant();
            var lastItem = restaurants.Last();

            newRest.Id = lastItem.Id + 1;
            newRest.Name = name;
            newRest.Cuisine = cuisine;
            newRest.Location = location;
            restaurants.Add(newRest);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from restaurant in restaurants
                   where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                   orderby restaurant.Id
                   select restaurant;
        }

        //My version, wrote before course example
        public IEnumerable<Restaurant> GetSingleRestaurant(int id)
        {
            return from resturant in restaurants
                   where resturant.Id == id
                   select resturant;
        }

        //Course version
        public Restaurant GetSingleRestaurant_2(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);

        }

        //Course version
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        //Course version
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        //Course version
        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return null;
        }
        //Course version
        public int Commit()
        {
            return 0;
        }
    }
}