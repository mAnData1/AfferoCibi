using Data.Commands;
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
        public AdminOrCustomerLogInViewModel(NavigationStore navigationStore, Func<AdminLiginViewModel> cereateAdminLiginViewModel, Func<CustomerOrderingViewModel> cereateCustomerOrderingViewModel)
        {
            CustomerLogIn = new NavigateCommand( navigationStore, cereateCustomerOrderingViewModel);

            AdminLogIn = new NavigateCommand( navigationStore, cereateAdminLiginViewModel);
        }
    }
}
