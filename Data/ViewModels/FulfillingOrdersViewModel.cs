using Data.Commands;
using Data.Commands.FulfilingOrderCommands;
using Data.Entities;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class FulfillingOrdersViewModel : BaseHelpViewModel
    {
        private int selectedOrderIndex = -1;

        public int SelectedOrderIndex
        {
            get { return selectedOrderIndex; }
            set { selectedOrderIndex = value; OnPropertyChanged(nameof(SelectedOrderIndex)); }
        }


        private ObservableCollection<MealViewModel> meals;
        public ObservableCollection<MealViewModel> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

        private ObservableCollection<OrderViewModel> orders;
        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public SendOrder SendOrderCommand { get; }
        public RejectOrder RejectOrderCommand { get; }
        public NavigateCommand NavigateToAdminCorrectionsCommand { get; }
        public FulfillingOrdersViewModel(NavigationService helpNavigationService, NavigationService adminCorrectionsNavigationService)
            : base(helpNavigationService)
        {
            Orders =  new ObservableCollection<OrderViewModel>();
            Orders.Add(new OrderViewModel(new Order("something,someting", DateTime.Now)));
            Orders.Add(new OrderViewModel(new Order("something,someting", DateTime.Now)));
            Orders.Add(new OrderViewModel(new Order("something,someting", DateTime.Now)));
            Orders.Add(new OrderViewModel(new Order("something,someting", DateTime.Now)));
            SendOrderCommand = new SendOrder(this);
            RejectOrderCommand = new RejectOrder(this);
            this.meals = new ObservableCollection<MealViewModel>();
            NavigateToAdminCorrectionsCommand = new NavigateCommand(adminCorrectionsNavigationService);
        }
    }
}
