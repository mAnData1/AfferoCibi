using Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class FulfillingOrdersViewModel : BaseViewModel
    {
        private ObservableCollection<MealViewModel> meals;
        public ObservableCollection<MealViewModel> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

        private ObservableCollection<OrderViewModel> orders;
        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public ICommand SendOrderCommand { get; }
        public ICommand RejectOrderCommand { get; }

        public FulfillingOrdersViewModel()
        {
            this.meals = new ObservableCollection<MealViewModel>();
            this.orders = new ObservableCollection<OrderViewModel>();

        }
    }
}
