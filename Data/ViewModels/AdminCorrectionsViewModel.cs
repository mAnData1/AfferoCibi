using Data.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
   public class AdminCorrectionsViewModel : BaseViewModel
    {
        private ObservableCollection<MealViewModel> meals;
        public ICollection<MealViewModel> Meals => meals;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChaneg(nameof(Name));}
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChaneg(nameof(Price));}
        }

        private string ingredients;

        public string Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; OnPropertyChaneg(nameof(Ingredients)); }
        }

        public ICommand AddMealCommand { get; }
        public ICommand DeleteMealCommand { get; }
        public ICommand UpdateMealCommand { get; }

        public AdminCorrectionsViewModel()
        {
            this.meals = new ObservableCollection<MealViewModel>();

            AddMealCommand = new AddMeal(this);
        }

    }
}
