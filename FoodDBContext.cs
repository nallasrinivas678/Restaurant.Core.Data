using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Service = Restaurant.Core.Services;

namespace Restaurant.Core.Data
{
    public class FoodDBContext: DbContext
    {
        public DbSet<Service.Restaurant> Restaurants { get; set; } 
    }
}
