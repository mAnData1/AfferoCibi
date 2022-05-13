using Data.Commands;
using Data.Commands.FulfilingOrderCommands;
using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
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
    public class FulfillingOrdersViewModel : BaseViewModelWithOrderService
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
            set { orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        public BaseCommand LoadOrdersCommand { get; }
        public SendOrder SendOrderCommand { get; }
        public RejectOrder RejectOrderCommand { get; }
        public NavigateCommand NavigateToAdminCorrectionsCommand { get; }
        public FulfillingOrdersViewModel(NavigationService helpNavigationService, NavigationService adminCorrectionsNavigationService, IOrderService orderService)
            : base(helpNavigationService, orderService)
        {
            Meals = new ObservableCollection<MealViewModel>();
            Orders = new ObservableCollection<OrderViewModel>();
            SendOrderCommand = new SendOrder(this);
            RejectOrderCommand = new RejectOrder(this);
            NavigateToAdminCorrectionsCommand = new NavigateCommand(adminCorrectionsNavigationService);
            LoadOrdersCommand = new LoadOrders<FulfillingOrdersViewModel>(this);
        }

        public static FulfillingOrdersViewModel LoadViewModel(NavigationService helpNavigationService, NavigationService adminCorrectionsNavigationService, IOrderService orderService)
        {
            FulfillingOrdersViewModel viewModel = new FulfillingOrdersViewModel(helpNavigationService, adminCorrectionsNavigationService, orderService);
            viewModel.LoadOrdersCommand.Execute(null);

            return viewModel;
        }

        public override void LoadOrders(ICollection<Order> orders)
        {
            foreach (var order in  orders)
            {
                Orders.Add(new OrderViewModel(order)); 
            }
        }
    }
}
