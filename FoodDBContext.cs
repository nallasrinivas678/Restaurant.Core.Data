using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Service = Restaurant.Core.Services;

namespace Restaurant.Core.Data
{
    public class FoodDBContext: DbContext
    {
        //to pass options to base class - FoodDBContext
        public FoodDBContext(DbContextOptions<FoodDBContext> options):base(options)
        {

        }    
        public DbSet<Service.Restaurant> Restaurants { get; set; } 
    }
}
