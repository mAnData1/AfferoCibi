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
    public class AdminLogInViewModel : BaseHelpViewModel<AdminLogInViewModel>
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private string bindablePassword;

        public string BindablePassword
        {
            get { return bindablePassword; }
            set { bindablePassword = value; OnPropertyChanged(nameof(BindablePassword)); }
        }

        public Submit SubmitCommand { get; }

        public AdminLogInViewModel(NavigationService<AdminCorrectionsViewModel, AdminLogInViewModel> adminCorrectionsNavigation, 
            NavigationService<HelpViewModel,AdminLogInViewModel> helpNavigationService)
            : base(helpNavigationService)
        {
            SubmitCommand = new Submit(this, adminCorrectionsNavigation);
        }
    }
}
