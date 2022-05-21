using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.HelpViewModleCommads
{
    public class NavigateBackCommand : BaseCommand
    {
        private readonly NavigationBackService navigationBackService;

        public NavigateBackCommand(NavigationBackService navigationBackService)
        {
            this.navigationBackService = navigationBackService;
        }
        public override void Execute(object? parameter)
        {
            navigationBackService.NavigateBack();
        }
    }
}
