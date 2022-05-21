using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<BaseViewModel> nextViewModel;
        private readonly Func<BaseViewModel> currentViewModel;

        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> nextViewModel, Func<BaseViewModel> currentViewModel)
        {
            this.navigationStore = navigationStore;
            this.nextViewModel = nextViewModel;
            this.currentViewModel = currentViewModel;
        }


        public void Navigate()
        {
            navigationStore.CurrentViewModel = nextViewModel();
            navigationStore.PrevViewModel = currentViewModel();
        }

    }
}
