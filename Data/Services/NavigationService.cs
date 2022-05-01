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
        private readonly Func<BaseViewModel> createViewModel;
        private readonly Func<BaseViewModel> prevViewModel;

        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> createViewModel, Func<BaseViewModel> prevViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.prevViewModel = prevViewModel;
        }


        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewModel();
            navigationStore.PrevViewModel = prevViewModel();
        }

    }
}
