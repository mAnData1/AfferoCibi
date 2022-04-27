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
    public class AdminOrCustomerLogInViewModel : BaseViewModel
    {
        public NavigateCommand CustomerLogIn { get; }

        public NavigateCommand AdminLogIn { get; }
        public AdminOrCustomerLogInViewModel(NavigationService customerOrderingViewNavigation, NavigationService adminLogInViewNavigation)
        {
            CustomerLogIn = new NavigateCommand(customerOrderingViewNavigation);

            AdminLogIn = new NavigateCommand(adminLogInViewNavigation);
        }
    }
}
