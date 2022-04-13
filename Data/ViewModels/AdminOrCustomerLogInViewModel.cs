using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels.EntitiesViewModels
{
    public class AdminOrCustomerLogInViewModel : BaseViewModel
    {
        public ICommand CustomerLogIn { get; }

        public ICommand AdminLogIn { get; }
    }
}
