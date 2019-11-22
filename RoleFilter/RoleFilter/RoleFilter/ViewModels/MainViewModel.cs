using MvvmHelpers;
using RoleFilter.Models;
using RoleFilter.Services.DataStore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RoleFilter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        protected IDataStoreService DataStoreService;

        public ObservableRangeCollection<Item> Items { get; set; }
        public ObservableRangeCollection<Item> AllItems { get; set; }
        public ObservableRangeCollection<string> FilterOptions { get; }

        string selectedFilter = "All";

        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                if (SetProperty(ref selectedFilter, value))
                    FilterItems();
            }
        }

        public ICommand LoadItemsCommand { get; }


        public MainViewModel()
        {
            DataStoreService = new DataStoreService();

            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            AllItems = new ObservableRangeCollection<Item>();

            FilterOptions = new ObservableRangeCollection<string>
                {
                    "All",
                    "Admin",
                    "Editor",
                    "Student"
                };

            LoadItemsCommand = new Command(async () => await LoadItemsCommandExecute());
        }

        void FilterItems()
        {
            Items.ReplaceRange(AllItems.Where(a => a.Role == SelectedFilter || SelectedFilter == "All"));
        }


        private async Task LoadItemsCommandExecute()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStoreService.GetItemsAsync();
                AllItems.ReplaceRange(items);
                FilterItems();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
