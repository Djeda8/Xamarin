using Basic_MVVM.ViewModels.Base;
using System.Threading.Tasks;

namespace Basic_MVVM.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
