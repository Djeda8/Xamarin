using PreferencesService.ViewModels.Base;
using PreferencesService.ViewModels.Settings;
using System.Threading.Tasks;

namespace PreferencesService.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand SettingsCommand => new DelegateCommand(async () => await SettingsCommandExecute());

        private async Task SettingsCommandExecute()
        {
            await NavigationService.NavigateToAsync<SettingsViewModel>();
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
