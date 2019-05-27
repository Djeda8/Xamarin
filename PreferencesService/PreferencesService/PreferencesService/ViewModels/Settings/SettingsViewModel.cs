using PreferencesService.Services.Dialog;
using PreferencesService.Services.Preferences;
using PreferencesService.ViewModels.Base;
using System.Threading.Tasks;

namespace PreferencesService.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _uri;
        private int _contador, _terminalNum;

        protected readonly IDialogService _dialogService;
        protected readonly IPreferencesService _preferencesService;

        public int ContadorTXT
        {
            get { return _contador; }
            set
            {
                _contador = value;
                RaisePropertyChanged();
            }
        }

        public int TerminalNumTXT
        {
            get { return _terminalNum; }
            set
            {
                _terminalNum = value;
                RaisePropertyChanged();
            }
        }

        public string URITXT
        {
            get { return _uri; }
            set
            {
                _uri = value;
                RaisePropertyChanged();
            }
        }

        public SettingsViewModel(IDialogService dialogService, IPreferencesService preferencesService)
        {
            _dialogService = dialogService;
            _preferencesService = preferencesService;
        }

        public DelegateCommand AcceptCommand => new DelegateCommand(AcceptCommandExecute);

        private async void AcceptCommandExecute()
        {
            if (TerminalNumTXT == 0)
            {
                await _dialogService.ShowMessage("Error", "Debe introducir un número de terminal");
                return;
            }

            if (string.IsNullOrEmpty(URITXT))
            {
                await _dialogService.ShowMessage("Error", "Debe introducir una URI");
                return;
            }

            AppSettings.Contador = ContadorTXT;
            AppSettings.TerminalNum = TerminalNumTXT;
            AppSettings.URI = URITXT;

            await _preferencesService.SetConfigData();
            await NavigationService.NavigateBackAsync();
        }

        public override Task InitializeAsync(object navigationData)
        {
            ContadorTXT = AppSettings.Contador;
            TerminalNumTXT = AppSettings.TerminalNum;
            URITXT = AppSettings.URI;

            return base.InitializeAsync(navigationData);
        }
    }
}
