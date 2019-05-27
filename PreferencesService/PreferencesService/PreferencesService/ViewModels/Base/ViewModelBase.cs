using PreferencesService.Services.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesService.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;
        

        public string _version;

        public string VersionTXT
        {
            get { return _version; }
            set
            {
                _version = value;
                RaisePropertyChanged();
            }
        }

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
