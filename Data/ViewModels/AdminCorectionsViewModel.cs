using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
   public class AdminCorectionsViewModel : BaseViewModel
    {
        private ObservableCollection<MealViewModel> meals = new ObservableCollection<MealViewModel>();
        public IEnumerable<MealViewModel> Meals => meals;

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

        public AdminCorectionsViewModel(ObservableCollection<MealViewModel> meals)
        {
            this.meals = new ObservableCollection<MealViewModel>();
        }

    }
}
