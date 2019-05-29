using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TabsControl.ViewModels.Base;

namespace TabsControl.Services.Navigation
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
