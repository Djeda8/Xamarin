using System;
using System.Threading.Tasks;
using EnglishApp.dou.com.ViewModels.Base;

namespace EnglishApp.dou.com.Services.Navigation
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