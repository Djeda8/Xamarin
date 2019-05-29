using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TabsControl.Services.Navigation;

namespace TabsControl.ViewModels.Base
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


        public virtual void OnBackButtonPressed()
        {
        }

        public virtual void ChangeActiveTab(int e)
        {
            Debug.WriteLine(string.Format("You has pressed the tab {0}.",e));
        }
    }
}
