using MultilingualApp.Resources;
using MultilingualApp.Services;
using MultilingualApp.ViewModels.Base;
using MultilingualApp.Views;
using Plugin.Multilingual;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultilingualApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var culture = CrossMultilingual.Current.DeviceCultureInfo;
            var culture = new CultureInfo(AppSettings.LanguageSettings);
            AppResources.Culture = culture;
            CrossMultilingual.Current.CurrentCultureInfo = culture;
            
            InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            base.OnResume();
        }
    }
}
