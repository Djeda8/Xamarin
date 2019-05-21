using Navigation_Service_Menu.ViewModels.Base;
using Navigation_Service_Menu.ViewModels.Screen1;
using Navigation_Service_Menu.ViewModels.Screen2;
using Navigation_Service_Menu.ViewModels.Screen3;
using Navigation_Service_Menu.ViewModels.Screen4;
using System.Threading.Tasks;

namespace Navigation_Service_Menu.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        public DelegateCommand GoScreen1Command => new DelegateCommand(async () => await GoScreen1CommandExecute());

        private async Task GoScreen1CommandExecute()
        {
            await NavigationService.NavigateToAsync<Screen1ViewModel>();
        }
        public DelegateCommand GoScreen2Command => new DelegateCommand(async () => await GoScreen2CommandExecute());

        private async Task GoScreen2CommandExecute()
        {
            await NavigationService.NavigateToAsync<Screen2ViewModel>();
        }
        public DelegateCommand GoScreen3Command => new DelegateCommand(async () => await GoScreen3CommandExecute());

        private async Task GoScreen3CommandExecute()
        {
            await NavigationService.NavigateToAsync<Screen3ViewModel>();
        }
        public DelegateCommand GoScreen4Command => new DelegateCommand(async () => await GoScreen4CommandExecute());

        private async Task GoScreen4CommandExecute()
        {
            await NavigationService.NavigateToAsync<Screen4ViewModel>();
        }
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
