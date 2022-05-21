﻿using Data.Commands;
using Data.Services;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class BaseHelpViewModel : BaseViewModel
    {
        public NavigateCommand NavigateToHelp { get; }

        public BaseHelpViewModel(NavigationService helpNavigationService)
        {
            NavigateToHelp = new NavigateCommand(helpNavigationService);
        }
    }
}
