using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Core.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodDBContext db;

        public SqlRestaurantData(FoodDBContext db)
        {
            this.db = db;
        }
        public Services.Restaurant Add(Services.Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            //returns no of rows affected in db table
            return db.SaveChanges();
        }

        public Services.Restaurant Delete(int Id)
        {
            var restaurant = GetRestaurantById(Id);
            if (restaurant != null) db.Restaurants.Remove(restaurant);
            return restaurant;
        }

        public Services.Restaurant GetRestaurantById(int restaurantId)
        {
            return db.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Services.Restaurant> GetRestaurantsByName(string name)
        {

            //Linq query to get data from database, all heavy lifting will be done on sql server.
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Services.Restaurant Update(Services.Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
