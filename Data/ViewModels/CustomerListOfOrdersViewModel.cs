using Data.Commands;
using Data.Entities;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class CustomerListOfOrdersViewModel : BaseHelpViewModel
    {
        private ObservableCollection<OrderViewModel> orders;

        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
        }

        public NavigateCommand NavigateToCustomerOrdering { get; }
        public CustomerListOfOrdersViewModel(NavigationService helpNavigationService, NavigationService customerOrderingNavigationService)
            : base(helpNavigationService)
        {
            NavigateToCustomerOrdering = new NavigateCommand(customerOrderingNavigationService);
        }
    }
}
