﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MVVM.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public ViewModelBase()
        {
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
