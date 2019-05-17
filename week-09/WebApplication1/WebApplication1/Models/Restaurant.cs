using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class Dish
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public string DishName { get; set; }

        public decimal Price { get; set; }
    }
}
