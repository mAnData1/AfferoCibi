using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly Admin admin;

        public string UserName => admin.UserName;
        public string Password => admin.Password;

        public AdminViewModel(Admin admin )
        {
            this.admin = admin;
        }
    }
}
