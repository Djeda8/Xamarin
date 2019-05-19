using Basic_MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basic_MVVM.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        public DelegateCommand SettingsCommand => new DelegateCommand(async () => await SettingsCommandExecute());

        private async Task SettingsCommandExecute()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                await NavigationService.NavigateToAsync<SettingsViewModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public DelegateCommand AccessFreeCommand => new DelegateCommand(async () => await AccessFreeCommandExecute());

        private async Task AccessFreeCommandExecute()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                AppSettings.User = null;
                await NavigationService.NavigateToAsync<ListadoViewModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public DelegateCommand AccessLoginCommand => new DelegateCommand(async () => await AccessLoginCommandExecute());

        private async Task AccessLoginCommandExecute()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                if (AppSettings.User != null)
                {
                    await NavigationService.NavigateToAsync<ListadoViewModel>();
                }
                else
                {
                    await NavigationService.NavigateToAsync<AccessLoginViewModel>();
                }
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public DelegateCommand SynchronizeCommand => new DelegateCommand(async () => await SynchronizeCommandExecute());

        private async Task SynchronizeCommandExecute()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                await NavigationService.NavigateToAsync<SynchronizeViewModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public DelegateCommand ExitCommand => new DelegateCommand(async () => await ExitCommandExecute());

        private async Task ExitCommandExecute()
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                await NavigationService.NavigateToAsync<ExitViewModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            UpdateVersion();
            return base.InitializeAsync(navigationData);
        }
    }
}
