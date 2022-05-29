using Data.Commands;
using Data.Commands.FulfilingOrderCommands;
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
    public class FulfillingOrdersViewModel : BaseViewModelWithOrderService<FulfillingOrdersViewModel>
    {
        private OrdersStore ordersStore;
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
            set { orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        public BaseCommand LoadOrdersCommand { get; }
        public SendOrder SendOrderCommand { get; }
        public RejectOrder RejectOrderCommand { get; }
        public NavigateCommand<AdminCorrectionsViewModel, FulfillingOrdersViewModel>  NavigateToAdminCorrectionsCommand { get; }
        public FulfillingOrdersViewModel(NavigationService<HelpViewModel, FulfillingOrdersViewModel> helpNavigationService, 
            NavigationService<AdminCorrectionsViewModel, FulfillingOrdersViewModel> adminCorrectionsNavigationService, OrdersStore ordersStore)
            : base(helpNavigationService, ordersStore)
        {
            Meals = new ObservableCollection<MealViewModel>();
            Orders = new ObservableCollection<OrderViewModel>();

            this.ordersStore = ordersStore;

            SendOrderCommand = new SendOrder(this, ordersStore);
            RejectOrderCommand = new RejectOrder(this, ordersStore);
            NavigateToAdminCorrectionsCommand = new NavigateCommand<AdminCorrectionsViewModel, FulfillingOrdersViewModel>(adminCorrectionsNavigationService);

            LoadOrdersCommand = new LoadOrders<FulfillingOrdersViewModel>(this);
        }

        public static FulfillingOrdersViewModel LoadViewModel(NavigationService<AdminCorrectionsViewModel, FulfillingOrdersViewModel> adminCorrectionsNavigationService,
             NavigationService<HelpViewModel, FulfillingOrdersViewModel> helpNavigationService, OrdersStore ordersStore)
        {
            FulfillingOrdersViewModel viewModel = new FulfillingOrdersViewModel(helpNavigationService, adminCorrectionsNavigationService, ordersStore);
            viewModel.LoadOrdersCommand.Execute(null);

            return viewModel;
        }

        public void ShowMeals(OrderViewModel order)
        {
            meals.Clear();
            foreach (var meal in order.Meals)
            {
                meals.Add(meal);
            }
        }

        public override void LoadOrders(IEnumerable<Order> orders)
        {
            foreach (var order in  orders)
            {
                Orders.Add(new OrderViewModel(order)); 
            }
        }
    }
}
