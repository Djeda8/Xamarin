using Basic_MVVM.Services.Navigation;
using Basic_MVVM.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Basic_MVVM
{
    public partial class App : Application

    {
        public App()
        {
            InitializeComponent();
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
