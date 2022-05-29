using Data.Commands;
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

namespace Data.ViewModels
{
    public class CustomerListOfOrdersViewModel : BaseViewModelWithOrderService<CustomerListOfOrdersViewModel>
    {
        private ObservableCollection<OrderViewModel> orders;
        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        public BaseCommand LoadOrdersCommand { get; }
        public NavigateCommand<CustomerOrderingViewModel, CustomerListOfOrdersViewModel>  NavigateToCustomerOrdering { get; }
        public CustomerListOfOrdersViewModel(NavigationService<HelpViewModel, CustomerListOfOrdersViewModel> helpNavigationService,
            NavigationService<CustomerOrderingViewModel, CustomerListOfOrdersViewModel> customerOrderingNavigationService,
            OrdersStore ordersStore)
            : base(helpNavigationService, ordersStore)
        {
            orders = new ObservableCollection<OrderViewModel>();
            NavigateToCustomerOrdering = new NavigateCommand<CustomerOrderingViewModel, CustomerListOfOrdersViewModel>(customerOrderingNavigationService);
            LoadOrdersCommand = new LoadOrders<CustomerListOfOrdersViewModel>(this); 
        }

        public static CustomerListOfOrdersViewModel LoadViewModel(NavigationService<CustomerOrderingViewModel, CustomerListOfOrdersViewModel> customerOrderingNavigationService, 
             NavigationService<HelpViewModel, CustomerListOfOrdersViewModel> helpNavigationService,
           OrdersStore ordersStore)
        {
            CustomerListOfOrdersViewModel viewModel = new CustomerListOfOrdersViewModel(helpNavigationService, customerOrderingNavigationService, ordersStore);
            viewModel.LoadOrdersCommand.Execute(null);

            return viewModel;
        }

        public override void LoadOrders(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                Orders.Add(new OrderViewModel(order));
            }
        }
    }
}
