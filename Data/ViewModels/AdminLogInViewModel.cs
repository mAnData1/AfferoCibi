using Data.Commands.AdminLogInCommands;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class AdminLogInViewModel : BaseHelpViewModel
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChaneg(nameof(UserName)); }
        }

        private string bindablePassword;

        public string BindablePassword
        {
            get { return bindablePassword; }
            set { bindablePassword = value; OnPropertyChaneg(nameof(BindablePassword)); }
        }

        public Submit SubmitCommand { get; }

        public AdminLogInViewModel(NavigationService adminCorrectionsNavigation, NavigationService helpNavigationService)
            : base(helpNavigationService)
        {
            SubmitCommand = new Submit(this, adminCorrectionsNavigation);
        }
    }
}
