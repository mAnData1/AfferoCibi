using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected bool enabled = true;

        public virtual bool Enabled
        {
            get { return enabled; }
            set { enabled = value; OnExecutedChanged(); }
        }

        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
