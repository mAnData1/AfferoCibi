using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class MealViewModel : ViewModelBase
    {
        private readonly Meal meal;

        public string Name => meal.Name;
        public decimal Price => meal.Price;
        public string Ingredients => meal.Ingredients;

        public MealViewModel(Meal meal)
        {
            this.meal = meal;
        }
    }
}
