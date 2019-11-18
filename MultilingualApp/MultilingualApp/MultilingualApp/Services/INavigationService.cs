using System;
using System.Threading.Tasks;
using MultilingualApp.ViewModels.Base;

namespace MultilingualApp.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateBackAsync();
        Task NavigateToAsync(Type viewModelType);
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task PopToRootAsync();
    }
}