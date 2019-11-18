using MultilingualApp.Models;
using MultilingualApp.Resources;
using MultilingualApp.ViewModels.Base;
using MultilingualApp.Views;
using Plugin.Multilingual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultilingualApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Language _selectedLanguage;

        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                Preferences.Set("LanguageSettings", _selectedLanguage.Code);
                var culture = new CultureInfo(_selectedLanguage.Code);
                AppResources.Culture = culture;
                CrossMultilingual.Current.CurrentCultureInfo = culture;
                Initial();
                //RaisePropertyChanged();
            }
        }

        private IList _listLanguages;

        public IList ListLanguages
        {
            get { return _listLanguages; }
            set
            {
                _listLanguages = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {

            ListLanguages = new List<Language>()
                {
                  new Language(){ Id=1, Code="es-ES", Name="Español" },
                  new Language(){ Id=1, Code="en-GB", Name="Inglés" },
                  new Language(){ Id=1, Code="fr-FR", Name="Francés" },
                  new Language(){ Id=1, Code="it-IT", Name="Italiano" },
                  new Language(){ Id=1, Code="pt-PT", Name="Portugués" },
                };
        }
                
        public DelegateCommand SecondCommand => new DelegateCommand(async () => await SecondCommandExecute());

        private async Task SecondCommandExecute()
        {
            await NavigationService.NavigateToAsync<SecondViewModel>();
        }

        private async Task Initial()
        {
            await NavigationService.InitializeAsync();
        }
    }
}
