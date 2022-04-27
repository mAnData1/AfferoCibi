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
   public class AdminCorrectionsViewModel : BaseViewModel
    {
        public ObservableCollection<MealViewModel> meals { get; set;}

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
        public BaseCommand DeleteMealCommand { get; }
        public BaseCommand UpdateMealCommand { get; }
        public BaseCommand SaveChangesCommand { get; }

        public AdminCorrectionsViewModel(NavigationService fulfillingOrdersViewNavigation)
        {
            meals = new ObservableCollection<MealViewModel>();
            ProceedCommand = new NavigateCommand(fulfillingOrdersViewNavigation);
            AddMealCommand = new AddMeal(this);
            UpdateMealCommand = new UpdateMeal(this);
            SaveChangesCommand = new SaveChanges(this);
            DeleteMealCommand = new DeleteMeal(this);
        }

    }
}
