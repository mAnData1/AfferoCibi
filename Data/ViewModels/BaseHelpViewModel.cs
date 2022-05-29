using Data.Commands;
using Data.Services;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class BaseHelpViewModel<TCurrentViewModel> : BaseViewModel
        where TCurrentViewModel : BaseViewModel
    {
        public NavigateCommand<HelpViewModel, TCurrentViewModel> NavigateToHelp { get; }

        public BaseHelpViewModel(NavigationService<HelpViewModel, TCurrentViewModel> helpNavigationService)
        {
            NavigateToHelp = new NavigateCommand<HelpViewModel, TCurrentViewModel>(helpNavigationService);
        }
    }
}
