using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class BaseViewModelWithMealServices : BaseHelpViewModel
    {
        public readonly IMealService mealService;
        public BaseViewModelWithMealServices(NavigationService helpNavigationService, IMealService mealService)
            : base(helpNavigationService)
        {
            this.mealService = mealService;
        }
        public abstract void LoadMealsList(ICollection<Meal> meals);
    }
}
