using DataBaseStoreCore.Models;
using DataBaseStoreCore.ViewModels.Base;
using System;
using System.Collections.ObjectModel;

namespace DataBaseStoreCore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public int Contador;

        private ObservableCollection<Line> _lines;

        public ObservableCollection<Line> Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            Contador = 1;
            LineService.DeleteAll();
            Lines = new ObservableCollection<Line>();
        }

        public DelegateCommand AddCommand => new DelegateCommand(AddCommandExecute);

        private void AddCommandExecute()
        {
            Line line = new Line()
            {
                Name = String.Format($"Line {Contador}"),
            };

            LineService.Insert(line);
            UpdateList();
            Contador++;
        }



        public DelegateCommand MinusCommand => new DelegateCommand(MinusCommandExecute);

        private void MinusCommandExecute()
        {
            var line = Lines[Lines.Count - 1];
            LineService.Remove(line);
            UpdateList();
            Contador--;
        }

        public DelegateCommand<Line> DelNotifyCommand => new DelegateCommand<Line>(DelNotifyCommandExecute);

        private void DelNotifyCommandExecute(Line line)
        {
            LineService.Remove(line);
            UpdateList();
        }

        private void UpdateList()
        {
            var myList = LineService.getAll();
            Lines = new ObservableCollection<Line>(myList);
        }
    }
}
