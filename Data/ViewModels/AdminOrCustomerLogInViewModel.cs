using Data.Commands;
using Data.Services;
using Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class AdminOrCustomerLogInViewModel : BaseHelpViewModel<AdminOrCustomerLogInViewModel>
    {

        public AdminOrCustomerLogInViewModel(NavigationService<CustomerOrderingViewModel, AdminOrCustomerLogInViewModel> customerOrderingViewNavigation, 
            NavigationService<AdminLogInViewModel, AdminOrCustomerLogInViewModel> adminLogInViewNavigation, 
            NavigationService<HelpViewModel, AdminOrCustomerLogInViewModel> helpNavigationService)
            : base(helpNavigationService)
        {
            CustomerLogIn = new NavigateCommand<CustomerOrderingViewModel, AdminOrCustomerLogInViewModel>(customerOrderingViewNavigation);

            AdminLogIn = new NavigateCommand<AdminLogInViewModel, AdminOrCustomerLogInViewModel>(adminLogInViewNavigation);
        }
        public NavigateCommand<CustomerOrderingViewModel, AdminOrCustomerLogInViewModel>  CustomerLogIn { get; }
        public NavigateCommand<AdminLogInViewModel, AdminOrCustomerLogInViewModel> AdminLogIn { get; }
    }
}
