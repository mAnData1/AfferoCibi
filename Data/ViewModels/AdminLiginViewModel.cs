using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class AdminLiginViewModel : ViewModelBase
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChaneg(nameof(UserName)); }
        }

        private int password;

        public int Password
        {
            get { return password; }
            set { password = value; OnPropertyChaneg(nameof(Password)); }
        }


    }
}
