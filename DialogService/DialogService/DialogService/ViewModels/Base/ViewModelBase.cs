using DialogService.Services.Dialog;
using DialogService.Services.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DialogService.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Services interfaces
        protected readonly INavigationService NavigationService;
        protected readonly IDialogService DialogService;

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
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
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

        public virtual void OnBackButtonPressed()
        {
        }
    }
}
