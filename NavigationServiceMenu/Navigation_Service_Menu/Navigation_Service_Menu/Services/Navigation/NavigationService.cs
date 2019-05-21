using Navigation_Service_Menu.ViewModels.Base;
using Navigation_Service_Menu.ViewModels.Main;
using Navigation_Service_Menu.ViewModels.Screen1;
using Navigation_Service_Menu.ViewModels.Screen2;
using Navigation_Service_Menu.ViewModels.Screen3;
using Navigation_Service_Menu.ViewModels.Screen4;
using Navigation_Service_Menu.Views.Base;
using Navigation_Service_Menu.Views.Main;
using Navigation_Service_Menu.Views.Screen1;
using Navigation_Service_Menu.Views.Screen2;
using Navigation_Service_Menu.Views.Screen3;
using Navigation_Service_Menu.Views.Screen4;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation_Service_Menu.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region Attributes
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }
        #endregion

        #region Constructor
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }
        #endregion

        // ** MAIN VIEW ** //
        public Task InitializeAsync()
        {
            return NavigateToAsync<MainViewModel>();
        }

        // ** NAVIGATE ** //
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), null);
        }

        // ** NAVIGATE WITH PARAMETER ** //
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        // ** NAVIGATE ** //
        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        // ** NAVIGATE WITH PARAMETER ** //
        protected virtual async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainView)
            {
                Application.Current.MainPage = new CustomNavigationPage(page);
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new CustomNavigationPage(page);
                }
            }
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            page.Appearing += async (object sender, EventArgs e) =>
            {
                await viewModel.InitializeAsync(parameter);
            };

            page.Disappearing += async (object sender, EventArgs e) =>
            {
                await viewModel.DesInitializeAsync(parameter);
            };

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            // Add Mappings ViewModels and Views
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(Screen1ViewModel), typeof(Screen1View));
            _mappings.Add(typeof(Screen2ViewModel), typeof(Screen2View));
            _mappings.Add(typeof(Screen3ViewModel), typeof(Screen3View));
            _mappings.Add(typeof(Screen4ViewModel), typeof(Screen4View));
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public async Task PopToRootAsync()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }
    }
}
