using MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //private bool _isCheck;

        //public bool IsCheck
        //{
        //    get { return _isCheck; }
        //    set
        //    {
        //        _isCheck = value;
        //        RaisePropertyChanged();
        //    }
        //}

        public MainViewModel()
        {
            _cliccounter = 0;
        }
        
        private int _cliccounter;

        public string Message
        {
            get { return string.Format("Botón pulsado {0} veces", _cliccounter); }
        }

        public DelegateCommand HelloCommand => new DelegateCommand(HelloCommandExecute);

        private void HelloCommandExecute()
        {
            _cliccounter++;
            RaisePropertyChanged("Message");
        }
    }
}
