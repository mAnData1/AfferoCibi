using Data.Services;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminLogInCommands
{
    public class Submit : BaseCommand
    {
        private AdminLogInViewModel adminLiginViewModel;
        private readonly NavigationService adminCorrectionsNavigation;

        public Submit(AdminLogInViewModel adminLiginViewModel, NavigationService adminCorrectionsNavigation)
        {
            this.adminLiginViewModel = adminLiginViewModel;
            this.adminCorrectionsNavigation = adminCorrectionsNavigation;
            adminLiginViewModel.PropertyChanged += TextBoxesChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(adminLiginViewModel.UserName)
                && !string.IsNullOrEmpty(adminLiginViewModel.BindablePassword)                
                && Enabled
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            if (adminLiginViewModel.UserName == "admin" && adminLiginViewModel.BindablePassword == "admin")
            {
                adminCorrectionsNavigation.Navigate();
            }
            else
            {
                ClearTextBoxes();
                throw new ArgumentException("Wrong password or username");
            }
        }

        private void TextBoxesChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(adminLiginViewModel.UserName)
               || e.PropertyName == nameof(adminLiginViewModel.BindablePassword))
               
            {
                OnExecutedChanged();
            }
        }
        private void ClearTextBoxes()
        {
            adminLiginViewModel.UserName= "";
            adminLiginViewModel.BindablePassword= "";
        }
    }
}
