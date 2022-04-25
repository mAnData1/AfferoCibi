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

        private string bindablePassword;

        public string BindablePassword
        {
            get { return bindablePassword; }
            set { bindablePassword = value; OnPropertyChaneg(nameof(BindablePassword)); }
        }

        public ICommand SubmitCommand { get; }

        public AdminLiginViewModel()
        {

        }
    }
}
