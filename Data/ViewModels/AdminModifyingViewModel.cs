using Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class AdminModifyingViewModel
    {

        public ObservableCollection<Meal> Meals { get; set; }  

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public string PossibleAllergens { get; set; }
    }
}
