using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class BaseViewModelWithMealServices<TCurrentViewModel> : BaseHelpViewModel<TCurrentViewModel>
        where TCurrentViewModel : BaseViewModel
    {
        public readonly MealsStore mealsStore;
        public BaseViewModelWithMealServices(NavigationService<HelpViewModel, TCurrentViewModel> helpNavigationService, MealsStore mealsStore)
            : base(helpNavigationService)
        {
            this.mealsStore = mealsStore;
        }
        public abstract void LoadMealsList(IEnumerable<Meal> meals);
    }
}
