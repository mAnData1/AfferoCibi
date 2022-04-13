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
        public IEnumerable<MealViewModel> Meals => meals;

        private ObservableCollection<OrderViewModel> orders;
        public IEnumerable<OrderViewModel> Orders => orders;

        public ICommand SendOrderCommand { get; }
        public ICommand RejectOrderCommand { get; }

        public FulfillingOrdersViewModel(ObservableCollection<MealViewModel> meals, ObservableCollection<OrderViewModel> orders)
        {
            this.meals = new ObservableCollection<MealViewModel>(meals);
            this.orders = new ObservableCollection<OrderViewModel>(orders);

        }
    }
}
