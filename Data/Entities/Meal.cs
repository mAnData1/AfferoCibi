using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Meal
    {
        public byte[] MealImage { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }

        public Meal(byte[] MealImage, string name, decimal price, string ingredients)
        {
            this.MealImage = MealImage;
            Name = name;
            Price = price;  
            Ingredients = ingredients;  
        }

    }
}
