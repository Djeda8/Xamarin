using Basic_button_command.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace Basic_button_command.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        // Vuelve pagina anterior
        Task NavigateBackAsync();

        // Vuelve al menu principal
        Task PopToRootAsync();
    }
}
