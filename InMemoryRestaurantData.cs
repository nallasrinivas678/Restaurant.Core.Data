using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Service = Restaurant.Core.Services;

namespace Restaurant.Core.Data
{
    public class InMemoryRestaurantData: IRestaurantData
    {

        //static data for temp 
        List<Service.Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Service.Restaurant>()
           {
               new Service.Restaurant{Id=1,Name="Bawarchi",Location="New Jersey, NY", Cusine=Service.CusineType.Indian},
               new Service.Restaurant{Id=2,Name="Johnny Carinos",Location="Miami, FL", Cusine=Service.CusineType.Italian},
               new Service.Restaurant{Id=3,Name="Casa Fiesta ",Location="California, CA", Cusine=Service.CusineType.Mexican},

           };
        }
        public IEnumerable<Service.Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Service.Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        public Service.Restaurant Add(Service.Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public Service.Restaurant Update(Service.Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(restaurants => restaurants.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cusine = updatedRestaurant.Cusine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Service.Restaurant Delete(int Id)
        {
            var restaurant = restaurants.SingleOrDefault(restaurant => restaurant.Id == Id);
            if (restaurant != null) restaurants.Remove(restaurant);
            return restaurant;
        }

        
    }
}
