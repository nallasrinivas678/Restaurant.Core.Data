using System.Collections.Generic;
using System.Text;
using Service = Restaurant.Core.Services;

namespace Restaurant.Core.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Service.Restaurant> GetRestaurantsByName(string name);
        Service.Restaurant GetRestaurantById(int restaurantId);
        Service.Restaurant Update(Service.Restaurant updatedRestaurant);
        Service.Restaurant Add(Service.Restaurant newRestaurant);
        Service.Restaurant Delete(int Id);
        int Commit();
    }
}
