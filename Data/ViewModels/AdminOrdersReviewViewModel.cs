using Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Data.ViewModels
{
    public class AdminOrdersReviewViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }
    }
}
