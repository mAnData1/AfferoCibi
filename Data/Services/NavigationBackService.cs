using Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class NavigationBackService
    {
        private readonly NavigationStore navigationStore;

        public NavigationBackService(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

        public void NavigateBack()
        {
            var store = navigationStore.CurrentViewModel;
            navigationStore.CurrentViewModel = navigationStore.PrevViewModel;
            navigationStore.PrevViewModel = store;
        }
    }
}
