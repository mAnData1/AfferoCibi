using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class MealViewModel : BaseViewModel
    {
        private Meal meal;

        public Guid Id 
        {
            get {return meal.Id;}
            set { meal.Id = value; } 
        }
        public byte[] MealImage 
        {
            get { return meal.MealImage; }
            set { meal.MealImage = value; } 
        }
        public string Name 
        {
            get { return meal.Name; } 
            set { meal.Name = value; } 
        }
        public decimal Price
        {
            get { return meal.Price; }
            set { meal.Price = value; }
        }
        public string Ingredients
        {
            get { return meal.Ingredients; }
            set { meal.Ingredients = value; }
        }
        public MealViewModel(Meal meal)
        {
            this.meal = meal;
        }

    }
}
