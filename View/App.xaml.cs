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
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=LiteraDB";
        private readonly NavigationStore navigationStore;
        public App()
        {
            navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions<AfferoCibiDBContext> options = new DbContextOptionsBuilder<AfferoCibiDBContext>().UseSqlServer(ConnectionString).Options;
            using (AfferoCibiDBContext afferoCibiDBContext = new AfferoCibiDBContext(options))
            {
                afferoCibiDBContext.Database.Migrate();
            }


            navigationStore.CurrentViewModel = new AdminOrCustomerLogInViewModel(
                new NavigationService( navigationStore, CreateCustomerOrderingViewModel, CreateAdminOrCustomerLogInViewModel), 
                new NavigationService(navigationStore, CreateAdminLiginViewModel, CreateAdminOrCustomerLogInViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminOrCustomerLogInViewModel));
           
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private AdminOrCustomerLogInViewModel CreateAdminOrCustomerLogInViewModel()
        {
            return new AdminOrCustomerLogInViewModel(new NavigationService(navigationStore, CreateCustomerOrderingViewModel, CreateAdminOrCustomerLogInViewModel),
                new NavigationService(navigationStore, CreateAdminLiginViewModel, CreateAdminOrCustomerLogInViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminOrCustomerLogInViewModel));
        }
        private HelpViewModel CreateHelpViewModel()
        {
           return new HelpViewModel(new NavigationBackService(navigationStore));
        }
        private FulfillingOrdersViewModel CreateFulfillingOrdersViewModel()
        {
            return new FulfillingOrdersViewModel(new NavigationService(navigationStore, CreateHelpViewModel, CreateFulfillingOrdersViewModel),
                new NavigationService(navigationStore, CreateAdminCorrectionsViewModel, CreateFulfillingOrdersViewModel));
        }
        private AdminCorrectionsViewModel CreateAdminCorrectionsViewModel()
        {
            return new AdminCorrectionsViewModel(new NavigationService(navigationStore,CreateFulfillingOrdersViewModel, CreateAdminCorrectionsViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminCorrectionsViewModel));
        }
        private AdminLogInViewModel CreateAdminLiginViewModel()
        {
            return new AdminLogInViewModel(new NavigationService(navigationStore, CreateAdminCorrectionsViewModel, CreateAdminLiginViewModel), 
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminLiginViewModel));
        }
        private CustomerListOfOrdersViewModel CreateCustomerListOfOrdersViewModel()
        {
            return new CustomerListOfOrdersViewModel(new NavigationService(navigationStore, CreateHelpViewModel, CreateCustomerListOfOrdersViewModel),
                new NavigationService(navigationStore,CreateCustomerOrderingViewModel,CreateFulfillingOrdersViewModel));
        }
        private CustomerOrderingViewModel CreateCustomerOrderingViewModel()
        {
            return new CustomerOrderingViewModel(new NavigationService(navigationStore, CreateCustomerListOfOrdersViewModel, CreateCustomerOrderingViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateCustomerOrderingViewModel));
        }
    }
}
