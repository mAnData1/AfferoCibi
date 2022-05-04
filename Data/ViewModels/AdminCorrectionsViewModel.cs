using Data.Commands;
using Data.Commands.AdminCorrectionsViewModelCommands;
using Data.Entities;
using Data.Services;
using Data.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
   public class AdminCorrectionsViewModel : BaseHelpViewModel
    {
        public ObservableCollection<MealCardAdminViewModel> Meals { get; set;}

        private MealCardAdminViewModel selectedMeal;
        public MealCardAdminViewModel SelectedMeal 
        {
            get { return selectedMeal; }
            set { selectedMeal = value; 
                OnPropertyChaneg(nameof(SelectedMeal));}  
        }

        private byte[] inputImage;

        public byte[] InputImage
        {
            get { return inputImage; }
            set { inputImage = value; }
        }
        private string inputName;

        public string InputName
        {
            get { return inputName; }
            set { inputName = value; OnPropertyChaneg(nameof(InputName));}
        }

        private decimal inputPrice;

        public decimal InputPrice
        {
            get { return inputPrice; }
            set { inputPrice = value; OnPropertyChaneg(nameof(InputPrice));}
        }

        private string inputIngredients;

        public string InputIngredients
        {
            get { return inputIngredients; }
            set { inputIngredients = value; OnPropertyChaneg(nameof(InputIngredients)); }
        }

        public NavigateCommand ProceedCommand { get; }
        public BaseCommand UploadImageCommand { get; }
        public BaseCommand AddMealCommand { get ; }
        public BaseCommand SaveChangesCommand { get; }

        public AdminCorrectionsViewModel(NavigationService fulfillingOrdersViewNavigation, NavigationService helpNavigationService)
            :base(helpNavigationService)
        {
            Meals = new ObservableCollection<MealCardAdminViewModel>();
            Meals.Add(new MealCardAdminViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            Meals.Add(new MealCardAdminViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            Meals.Add(new MealCardAdminViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            Meals.Add(new MealCardAdminViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            ProceedCommand = new NavigateCommand(fulfillingOrdersViewNavigation);
            AddMealCommand = new AddMeal(this);
            SaveChangesCommand = new SaveChanges(this);
        }

    }
}
