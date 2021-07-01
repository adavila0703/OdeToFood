using System.Collections.Generic;
using System;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        IEnumerable<Restaurant> GetSingleRestaurant(int id);
        Restaurant GetSingleRestaurant_2(int id);

        public void RemoveRest(int id);
        public void EditRest(int id, string name, CuisineType cuisine, string location);
        public void AddNew(string name, CuisineType cuisine, string location);

        //Course Version
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}