using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class NavigationService<TNextViewModel, TCurrentViewModel> 
        where TNextViewModel : BaseViewModel
        where TCurrentViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<TNextViewModel> nextViewModel;
        private readonly Func<TCurrentViewModel> currentViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TNextViewModel> nextViewModel, Func<TCurrentViewModel> currentViewModel)
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
