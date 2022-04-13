using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class AdminLiginViewModel : BaseViewModel
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

        public ICommand SubmitCommand { get; }

        public AdminLiginViewModel()
        {

        }
    }
}
