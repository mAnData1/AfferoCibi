using Data.Entities;
using Data.Services.Interfaces;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Stores
{
    public class MealsStore
    {
        private readonly List<Meal> meals;
        public IEnumerable<Meal> Meals => meals;

        private readonly IMealService mealService;

        private readonly Lazy<Task> InitializeLazy;

        public MealsStore(IMealService mealService)
        {
            meals = new List<Meal>();
            this.mealService = mealService;
            InitializeLazy = new Lazy<Task>(Initialize);
        }

        public async Task AddMeal(Meal meal)
        {
            await mealService.CreateAsync(meal);

            meals.Add(meal);
        }

        public async Task RemoveMeal(Meal meal)
        {
            await mealService.DeleteAsync(meal);

            meals.Remove(meal);
        }

        public async Task<Guid> GetIDAsync(Meal meal)
        {
            return await mealService.GetIDAsync(meal);
        }
        public async Task Update(Guid id, Meal meal)
        {
            await mealService.UpdateNameIncudedAsync(id, meal);
        }

        public async Task LoadMeals()
        {
            await InitializeLazy.Value;
        }

        private async Task Initialize()
        {
            ICollection<Meal> meals = await mealService.GetAllAsync();

            this.meals.Clear();
            this.meals.AddRange(meals);
        }
    }
}
