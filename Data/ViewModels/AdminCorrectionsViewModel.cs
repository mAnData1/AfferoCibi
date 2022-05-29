using Data.Commands;
using Data.Commands.AdminCorrectionsViewModelCommands;
using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using Data.Stores;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class AdminCorrectionsViewModel : BaseViewModelWithMealServices<AdminCorrectionsViewModel>
    {
        public ObservableCollection<MealCardAdminViewModel> Meals { get; set; }

        private Guid updatedMealID;
        public Guid UpdatedMealID
        {
            get { return updatedMealID; }
            set
            {
                updatedMealID = value;
                OnPropertyChanged(nameof(UpdatedMealID));
            }
        }

        private MealCardAdminViewModel updatedMeal;

        public MealCardAdminViewModel UpdatedMeal
        {
            get { return updatedMeal; }
            set
            {
                updatedMeal = value;
                OnPropertyChanged(nameof(UpdatedMeal));
            }
        }


        private byte[] inputImage;

        public byte[] InputImage
        {
            get { return inputImage; }
            set 
            { 
                inputImage = value; 
                OnPropertyChanged(nameof(InputImage));
            }
        }
        private string inputName;

        public string InputName
        {
            get { return inputName; }
            set { inputName = value; OnPropertyChanged(nameof(InputName)); }
        }

        private decimal inputPrice;

        public decimal InputPrice
        {
            get { return inputPrice; }
            set { inputPrice = value; OnPropertyChanged(nameof(InputPrice)); }
        }

        private string inputIngredients;

        public string InputIngredients
        {
            get { return inputIngredients; }
            set { inputIngredients = value; OnPropertyChanged(nameof(InputIngredients)); }
        }

        public NavigateCommand<FulfillingOrdersViewModel, AdminCorrectionsViewModel> ProceedCommand { get; }
        public BaseCommand UploadImageCommand { get; }
        public BaseCommand AddMealCommand { get; }
        public BaseCommand SaveChangesCommand { get; }
        public BaseCommand LoadMealsCommand { get; }

        public AdminCorrectionsViewModel(NavigationService<FulfillingOrdersViewModel, AdminCorrectionsViewModel> fulfillingOrdersViewNavigation, 
            NavigationService<HelpViewModel,AdminCorrectionsViewModel> helpNavigationService, MealsStore mealsStore)
            : base(helpNavigationService, mealsStore)
        {
            Meals = new ObservableCollection<MealCardAdminViewModel>();
            LoadMealsCommand = new LoadMeals<AdminCorrectionsViewModel>(this);
            ProceedCommand = new NavigateCommand<FulfillingOrdersViewModel, AdminCorrectionsViewModel> (fulfillingOrdersViewNavigation);
            AddMealCommand = new AddMeal(this, mealsStore);
            SaveChangesCommand = new SaveChanges(this,mealsStore);
        }

        public static AdminCorrectionsViewModel LoadViewModel(NavigationService<FulfillingOrdersViewModel, AdminCorrectionsViewModel> fulfillingOrdersViewNavigation, NavigationService<HelpViewModel, AdminCorrectionsViewModel> helpNavigationService, MealsStore mealsStore)
        {
            AdminCorrectionsViewModel viewModel = new AdminCorrectionsViewModel(fulfillingOrdersViewNavigation, helpNavigationService, mealsStore);
            viewModel.LoadMealsCommand.Execute(null);
            return viewModel;
        }

        public override void LoadMealsList(IEnumerable<Meal> meals)
        {
            Meals.Clear();
            foreach (var meal in meals)
            {
                Meals.Add(new MealCardAdminViewModel(meal, this, mealsStore));
            }
        }
        public void RefreshMealsList()
        {
            LoadMealsCommand.Execute(null);
        }

    }
}

