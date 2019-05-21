using Basic_button_command;
using Basic_button_command.ViewModels.Base;
using System.Threading.Tasks;

namespace Basic_MVVM.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        public DelegateCommand TestCommand => new DelegateCommand(async () => await TestCommandExecute());

        private async Task TestCommandExecute()
        {
            string title = "title";
            string message = "message";
            await App.Current.MainPage.DisplayAlert(title, message, "Aceptar");
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
