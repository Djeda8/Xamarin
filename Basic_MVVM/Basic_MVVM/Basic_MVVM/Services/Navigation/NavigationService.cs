using Basic_MVVM.ViewModels.Base;
using Basic_MVVM.ViewModels.Main;
using Basic_MVVM.Views.Base;
using Basic_MVVM.Views.Main;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Basic_MVVM.Services.Navigation
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
