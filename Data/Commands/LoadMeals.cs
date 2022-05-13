using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class LoadMeals<TViewModel> : BaseAsyncCommand where TViewModel : BaseViewModelWithMealServices
    {
        private TViewModel ViewModel;
        public LoadMeals(TViewModel ViewModel)
        {
            this.ViewModel = ViewModel;
        }
        
        public override async Task ExecuteAsync(object? parameter)
        {
            ICollection<Meal> meals = await ViewModel.mealService.GetAllAsync();

            ViewModel.LoadMealsList(meals);
        }
    }
}
