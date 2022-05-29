using Data.Services;
using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class NavigateCommand<TNextViewModel, TCurrentViewModel> : BaseCommand 
        where TNextViewModel : BaseViewModel
        where TCurrentViewModel : BaseViewModel
    {
        private readonly NavigationService<TNextViewModel, TCurrentViewModel> navigateServices;

        public NavigateCommand(NavigationService<TNextViewModel, TCurrentViewModel> navigateServices)
        {
            this.navigateServices = navigateServices;
        }

        public override void Execute(object? parameter)
        {
            navigateServices.Navigate();
        }
    }
}
