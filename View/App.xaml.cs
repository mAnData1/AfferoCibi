﻿using Data.Stores;
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

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Server=DESKTOP-QNFMT3E;Database=AfferoCibiDb;Trusted_Connection=True;";
        
        private readonly AfferoCibiDBContextFactory DbFactory;
        private readonly NavigationStore navigationStore;

        private readonly IMealService mealService;
        private readonly IOrderService orderService;
        private readonly IUnitOfWork unitOfWork;

        public App()
        {           
            DbFactory = new AfferoCibiDBContextFactory(ConnectionString);
            unitOfWork = new UnitOfWork(DbFactory.CreateDbContext());
            navigationStore = new NavigationStore();
            mealService = new MealService(unitOfWork);
            orderService = new OrderService(unitOfWork);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (AfferoCibiDBContext afferoCibiDBContext = DbFactory.CreateDbContext())
            {
                afferoCibiDBContext.Database.Migrate();
            }

            navigationStore.CurrentViewModel = new AdminOrCustomerLogInViewModel(
                new NavigationService(navigationStore, CreateCustomerOrderingViewModel, CreateAdminOrCustomerLogInViewModel),
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
            return FulfillingOrdersViewModel.LoadViewModel(new NavigationService(navigationStore, CreateHelpViewModel, CreateFulfillingOrdersViewModel),
                new NavigationService(navigationStore, CreateAdminCorrectionsViewModel, CreateFulfillingOrdersViewModel), orderService);
        }
        private AdminCorrectionsViewModel CreateAdminCorrectionsViewModel()
        {
            return AdminCorrectionsViewModel.LoadViewModel(new NavigationService(navigationStore, CreateFulfillingOrdersViewModel, CreateAdminCorrectionsViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminCorrectionsViewModel), mealService);
        }
        private AdminLogInViewModel CreateAdminLiginViewModel()
        {
            return new AdminLogInViewModel(new NavigationService(navigationStore, CreateAdminCorrectionsViewModel, CreateAdminLiginViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateAdminLiginViewModel));
        }
        private CustomerListOfOrdersViewModel CreateCustomerListOfOrdersViewModel()
        {
            return CustomerListOfOrdersViewModel.LoadViewModel(new NavigationService(navigationStore, CreateHelpViewModel, CreateCustomerListOfOrdersViewModel),
                new NavigationService(navigationStore, CreateCustomerOrderingViewModel, CreateFulfillingOrdersViewModel), orderService);
        }
        private CustomerOrderingViewModel CreateCustomerOrderingViewModel()
        {
            return CustomerOrderingViewModel.LoadViewModel(new NavigationService(navigationStore, CreateCustomerListOfOrdersViewModel, CreateCustomerOrderingViewModel),
                new NavigationService(navigationStore, CreateHelpViewModel, CreateCustomerOrderingViewModel), mealService, orderService);
        }
    }
}
