using SelectedIconConverter.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectedIconConverter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isCheck;

        public bool IsCheck
        {
            get { return _isCheck; }
            set
            {
                _isCheck = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            IsCheck = false;
        }
    }
}
