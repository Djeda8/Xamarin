using Login.Services.Dialog;
using Login.Services.Login;
using Login.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace Login.ViewModels.Login
{
    class LoginViewModel : ViewModelBase
    {
        protected readonly IDialogService _dialogService;
        protected readonly ILoginService _loginService;

        private string _idUsuario;

        public string IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
                RaisePropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        private string _result;

        public string ResultTXT
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public LoginViewModel()
        {
            _dialogService = new DialogService();
            _loginService = new LoginService();
            Initialize();
        }

        public DelegateCommand LoginCommand => new DelegateCommand(async () => await LoginCommandExecute());

        private async Task LoginCommandExecute()
        {
            try
            {
                if (String.IsNullOrEmpty(_idUsuario))
                {
                    await _dialogService.ShowMessage("Warning",$"El campo LOGIN es obligatorio");
                    return;
                }

                var _login = await _loginService.Login(_idUsuario, _password);

                if (_login != null)
                {
                    GlobalSettings.LoginData = _login;

                    IdUsuario = string.Empty;
                    Password = string.Empty;

                    // Poner nombre usuario
                    ResultTXT = _login.nombreUsuario;
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessage("Error",$"RestServiceError : {ex.Message}");
            }
            finally
            {

            }
        }

        public void Initialize()
        {
            ResultTXT = "Not user";
        }
    }
}
