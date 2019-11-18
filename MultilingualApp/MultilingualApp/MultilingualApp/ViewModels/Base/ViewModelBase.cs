using MultilingualApp.Resources;
using MultilingualApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualApp.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public virtual Task DesInitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
