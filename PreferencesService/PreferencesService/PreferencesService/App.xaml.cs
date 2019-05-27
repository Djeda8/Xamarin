using PreferencesService.Models;
using PreferencesService.Services.Navigation;
using PreferencesService.Services.Preferences;
using PreferencesService.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PreferencesService
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitNavigation();
        }

        private async Task InitializeData()
        {
            var PreferencesService = ViewModelLocator.Instance.Resolve<IPreferencesService>();

            PreferencesDataObject preferencesDataObject = await PreferencesService.GetPreferencesDataObject();

            if (preferencesDataObject == null)
            {
                await PreferencesService.NewPreferencesDataObject();
            }
            else
            {
                await PreferencesService.GetPreferencesData();
            }
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitializeData();
            await InitNavigation();

            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
