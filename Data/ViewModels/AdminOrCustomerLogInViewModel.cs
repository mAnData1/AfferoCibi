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
    public class AdminOrCustomerLogInViewModel : BaseHelpViewModel
    {
        public NavigateCommand CustomerLogIn { get; }

        public NavigateCommand AdminLogIn { get; }
        public AdminOrCustomerLogInViewModel(NavigationService customerOrderingViewNavigation, NavigationService adminLogInViewNavigation, 
            NavigationService helpNavigationService)
            : base(helpNavigationService)
        {
            CustomerLogIn = new NavigateCommand(customerOrderingViewNavigation);

            AdminLogIn = new NavigateCommand(adminLogInViewNavigation);
        }
    }
}
