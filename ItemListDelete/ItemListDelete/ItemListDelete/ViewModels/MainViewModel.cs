using ItemListDelete.Models;
using ItemListDelete.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ItemListDelete.ViewModels
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
            Lines = new ObservableCollection<Line>();
        }

        public DelegateCommand AddCommand => new DelegateCommand(AddCommandExecute);

        private void AddCommandExecute()
        {
            Line line = new Line()
            {
                Id = Contador,
                Name = String.Format($"Line {Contador}"),
            };

            Lines.Add(line);

            Contador++;
        }

        public DelegateCommand MinusCommand => new DelegateCommand(MinusCommandExecute);

        private void MinusCommandExecute()
        {
            Lines.RemoveAt(Lines.Count-1);
            Contador--;
        }

        public DelegateCommand<Line> DelNotifyCommand => new DelegateCommand<Line>(DelNotifyCommandExecute);

        private void DelNotifyCommandExecute(Line line)
        {
            Lines.Remove(line);
        }
    }
}
