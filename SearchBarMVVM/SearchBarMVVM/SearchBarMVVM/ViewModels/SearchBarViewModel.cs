using SearchBarMVVM.Services.DataStore;
using SearchBarMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SearchBarMVVM.ViewModels
{
    class SearchBarViewModel : ViewModelBase
    {
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            SearchResults = DataStoreService.GetSearchResults(query);
        });

        List<string> searchResults = DataStoreService.Sports;

        public List<string> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                RaisePropertyChanged();
            }
        }

        public void PerformSearchRealtime(string newTextValue)
        {
            SearchResults = DataStoreService.GetSearchResults(newTextValue);
        }
    }
}
