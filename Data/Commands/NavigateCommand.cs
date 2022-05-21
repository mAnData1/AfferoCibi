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
    public class NavigateCommand : BaseCommand
    {
        private readonly NavigationService navigateServices;

        public NavigateCommand(NavigationService navigateServices)
        {
            this.navigateServices = navigateServices;
        }

        public override void Execute(object? parameter)
        {
            navigateServices.Navigate();
        }
    }
}
