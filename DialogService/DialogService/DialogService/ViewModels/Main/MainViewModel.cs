﻿using DialogService.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DialogService.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    
        public DelegateCommand TestCommand => new DelegateCommand(async () => await TestCommandExecute());

        private async Task TestCommandExecute()
        {
            string title = "title";
            string message = "message";
            await _dialogService.ShowMessage(title, message);
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
