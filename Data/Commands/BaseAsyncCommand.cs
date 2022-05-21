using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public abstract class BaseAsyncCommand : BaseCommand
    {
        private bool isExecuting;

        private bool IsExecuting
        {
            get { return isExecuting; }
            set { isExecuting = value; OnExecutedChanged();}
        }

        public override async void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;       
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting
                && base.CanExecute(parameter);
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
