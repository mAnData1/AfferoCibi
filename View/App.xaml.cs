using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data.Services;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;
        public App()
        {
            navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = new AdminOrCustomerLogInViewModel(new NavigationService( navigationStore, CreateCustomerOrderingViewModel), new NavigationService(navigationStore, CreateAdminLiginViewModel));
           
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private FulfillingOrdersViewModel CreateFulfillingOrdersViewModel()
        {
            return new FulfillingOrdersViewModel();
        }
        private AdminCorrectionsViewModel CreateAdminCorrectionsViewModel()
        {
            return new AdminCorrectionsViewModel(new NavigationService(navigationStore,CreateFulfillingOrdersViewModel));
        }
        private AdminLogInViewModel CreateAdminLiginViewModel()
        {
            return new AdminLogInViewModel(new NavigationService(navigationStore, CreateAdminCorrectionsViewModel));
        }
        private CustomerOrderingViewModel CreateCustomerOrderingViewModel()
        {
            return new CustomerOrderingViewModel();
        }
    }
}
