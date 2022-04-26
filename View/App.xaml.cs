using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            navigationStore.CurrentViewModel = new AdminOrCustomerLogInViewModel(navigationStore, CreateAdminLiginViewModel, CreateCustomerOrderingViewModel);
           
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private AdminLiginViewModel CreateAdminLiginViewModel()
        {
            return new AdminLiginViewModel(navigationStore,)
        }
        private CustomerOrderingViewModel CreateCustomerOrderingViewModel()
        {
            return new CustomerOrderingViewModel();
        }
    }
}
