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
using Data.Services.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=AfferoCibiDB";
       
        private readonly IHost host;
        public App()
        {
            host = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     services.AddSingleton<AfferoCibiDBContextFactory>(new AfferoCibiDBContextFactory(ConnectionString));
                     services.AddSingleton<IUnitOfWork, UnitOfWork>();
                     services.AddSingleton<IMealService, MealService>();
                     services.AddSingleton<IOrderService, OrderService>();

                     services.AddSingleton<NavigationStore>();
                     services.AddSingleton<MealsStore>();
                     services.AddSingleton<OrdersStore>();

                     //Registering the ViewModels
                     services.AddTransient<AdminOrCustomerLogInViewModel>();
                     services.AddTransient<HelpViewModel>();
                     services.AddTransient<AdminLogInViewModel>();
                     services.AddTransient<FulfillingOrdersViewModel>((s) => LoadFulfillingOrdersViewModel(s));
                     services.AddTransient<AdminCorrectionsViewModel>((s) => LoadAdminCorrectionsViewModel(s));
                     services.AddTransient<CustomerOrderingViewModel>((s) => LoadCustomerOrderingViewModel(s));
                     services.AddTransient<CustomerListOfOrdersViewModel>((s) => LoadCustomerListOfOrdersViewModel(s));

                     //StartUp service
                     services.AddSingleton<NavigationService<AdminOrCustomerLogInViewModel, HelpViewModel>>();

                     //AdminOrCustomerLogIn Navigation
                     services.AddSingleton<NavigationService<CustomerOrderingViewModel, AdminOrCustomerLogInViewModel>>();
                     services.AddSingleton<NavigationService<AdminLogInViewModel, AdminOrCustomerLogInViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, AdminOrCustomerLogInViewModel>>();

                     //AdminLogIn Havigation
                     services.AddSingleton<NavigationService<AdminCorrectionsViewModel, AdminLogInViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, AdminLogInViewModel>>();

                     //CustomerOrdering Navigation
                     services.AddSingleton<NavigationService<CustomerListOfOrdersViewModel, CustomerOrderingViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, CustomerOrderingViewModel>>();

                     //CustomerListOfOrders Navigation
                     services.AddSingleton<NavigationService<CustomerOrderingViewModel, CustomerListOfOrdersViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, CustomerListOfOrdersViewModel>>();

                     //AdminCorrections Navigation
                     services.AddSingleton<NavigationService<FulfillingOrdersViewModel, AdminCorrectionsViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, AdminCorrectionsViewModel>>();

                     //FulfilingOrders Navigations
                     services.AddSingleton<NavigationService<AdminCorrectionsViewModel, FulfillingOrdersViewModel>>();
                     services.AddSingleton<NavigationService<HelpViewModel, FulfillingOrdersViewModel>>();

                     // Help Navigation
                     services.AddSingleton<NavigationBackService>();

                     //Registering funcs which create ViewModels
                     services.AddSingleton<Func<AdminOrCustomerLogInViewModel>>((s) => () => s.GetRequiredService<AdminOrCustomerLogInViewModel>());
                     services.AddSingleton<Func<HelpViewModel>>((s) => () => s.GetRequiredService<HelpViewModel>());
                     services.AddSingleton<Func<FulfillingOrdersViewModel>>((s) => () => s.GetRequiredService<FulfillingOrdersViewModel>());
                     services.AddSingleton<Func<AdminCorrectionsViewModel>>((s) => () => s.GetRequiredService<AdminCorrectionsViewModel>());
                     services.AddSingleton<Func<AdminLogInViewModel>>((s) => () => s.GetRequiredService<AdminLogInViewModel>());
                     services.AddSingleton<Func<CustomerOrderingViewModel>>((s) => () => s.GetRequiredService<CustomerOrderingViewModel>());
                     services.AddSingleton<Func<CustomerListOfOrdersViewModel>>((s) => () => s.GetRequiredService<CustomerListOfOrdersViewModel>());
                     
                     services.AddSingleton<MainWindowViewModel>();
                     services.AddSingleton(s => new MainWindow()
                     {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                     }
                      );
                 })
                 .Build();
        }

        private CustomerListOfOrdersViewModel LoadCustomerListOfOrdersViewModel(IServiceProvider s)
        {
            return CustomerListOfOrdersViewModel.LoadViewModel(
                s.GetRequiredService<NavigationService<CustomerOrderingViewModel, CustomerListOfOrdersViewModel>>(),
                s.GetRequiredService<NavigationService<HelpViewModel, CustomerListOfOrdersViewModel>>(),
                s.GetRequiredService<OrdersStore>());
        }

        private CustomerOrderingViewModel LoadCustomerOrderingViewModel(IServiceProvider s)
        {
            return CustomerOrderingViewModel.LoadViewModel(
                s.GetRequiredService<NavigationService<CustomerListOfOrdersViewModel, CustomerOrderingViewModel>>(),
                s.GetRequiredService<NavigationService<HelpViewModel, CustomerOrderingViewModel>>(),
                s.GetRequiredService<MealsStore>(),
                s.GetRequiredService<OrdersStore>());
        }

        private AdminCorrectionsViewModel LoadAdminCorrectionsViewModel(IServiceProvider s)
        {
            return AdminCorrectionsViewModel.LoadViewModel(
                s.GetRequiredService<NavigationService<FulfillingOrdersViewModel, AdminCorrectionsViewModel>>(),
                s.GetRequiredService<NavigationService<HelpViewModel, AdminCorrectionsViewModel>>(),
                s.GetRequiredService<MealsStore>());
        }

        private FulfillingOrdersViewModel LoadFulfillingOrdersViewModel(IServiceProvider s)
        {
            return FulfillingOrdersViewModel.LoadViewModel(
                s.GetRequiredService<NavigationService<AdminCorrectionsViewModel, FulfillingOrdersViewModel>>(),
                s.GetRequiredService<NavigationService<HelpViewModel, FulfillingOrdersViewModel>>(),
                s.GetRequiredService<OrdersStore>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            AfferoCibiDBContextFactory DbFactory = host.Services.GetRequiredService<AfferoCibiDBContextFactory>();
            using (AfferoCibiDBContext afferoCibiDBContext = DbFactory.CreateDbContext())
            {
                afferoCibiDBContext.Database.Migrate();
            }

            NavigationService<AdminOrCustomerLogInViewModel, HelpViewModel> navigationService = host.Services.GetRequiredService<NavigationService<AdminOrCustomerLogInViewModel, HelpViewModel>>();
            navigationService.Navigate();

            MainWindow = host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.Dispose();

            base.OnExit(e);
        }

    }
}
