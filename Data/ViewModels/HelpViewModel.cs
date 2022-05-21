using Data.Commands;
using Data.Commands.HelpViewModleCommads;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class HelpViewModel : BaseViewModel
    {

        public HelpViewModel(NavigationBackService navigationBack)
        {
            NavigateBackCommand = new NavigateBackCommand(navigationBack);
        }
        public NavigateBackCommand NavigateBackCommand { get; }
    }
}
