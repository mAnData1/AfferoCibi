using Data.Commands;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class BaseHelpViewModel: BaseViewModel
    {
        public NavigateCommand NavigateToHelp { get; }
        public BaseHelpViewModel(NavigationService helpNavigationService)
        {
            NavigateToHelp = new NavigateCommand(helpNavigationService);
        }
    }
}
