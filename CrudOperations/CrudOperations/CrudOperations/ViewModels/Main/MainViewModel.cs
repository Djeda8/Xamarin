using CrudOperations.Models;
using CrudOperations.Services.Sqlite;
using CrudOperations.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        protected readonly ISqliteService _sqliteService;

        private string _name,_email,_phone;
        private int _age;

        private User user;

        public string NameTXT {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public int AgeTXT
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged();
            }
        }
        public string EmailTXT
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }
        public string PhoneTXT
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel(ISqliteService sqliteService)
        {
            _sqliteService = sqliteService;
        }

        public DelegateCommand SaveCommand => new DelegateCommand(SaveCommandExecute);

        private async void SaveCommandExecute()
        {
            if (String.IsNullOrEmpty(NameTXT))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must entry a name.", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(PhoneTXT))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must entry a phone number.", "Aceptar");
                return;
            }

            user = new User()
            {
                Name = NameTXT,
                Age = AgeTXT,
                Email = EmailTXT,
                Phone = PhoneTXT
            };
            await _sqliteService.Insert(user);
            ResetUser();
        }

        public DelegateCommand SearchCommand => new DelegateCommand(SearchCommandExecute);

        private async void SearchCommandExecute()
        {
            if (String.IsNullOrEmpty(NameTXT))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must entry a name.", "Aceptar");
                return;
            }

            user = await _sqliteService.GetUser(_name);
            if (user != null)
            {
                UpdateUser();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "This name isn´t in the BBDD.", "Aceptar");
            }
        }

        private void UpdateUser()
        {
            PhoneTXT = user.Phone;
            EmailTXT = user.Email;
            AgeTXT = user.Age;
        }

        public DelegateCommand DeleteCommand => new DelegateCommand(DeleteCommandExecute);

        private async void DeleteCommandExecute()
        {
            if (user.Id == 0)
            {
                ResetUser();
                return;
            }
            if(user.Name != NameTXT)
            {
                ResetUser();
                return;
            }
            else 
            {
                await _sqliteService.DeleteUser(user);
                ResetUser();
            }
        }

        private void ResetUser()
        {
            NameTXT = "";
            PhoneTXT = "";
            EmailTXT = "";
            AgeTXT = 0;
        }
    }
}
