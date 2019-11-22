using EnglishApp.dou.com.ViewModels.Base;
using EnglishApp.dou.com.ViewModels.EnglishWord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.dou.com.ViewModels.Main
{
    class MainViewModel : ViewModelBase
    {
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public DelegateCommand EnglishWordCommand => new DelegateCommand(async () => await EnglishWordCommandExecute());

        private async Task EnglishWordCommandExecute()
        {
            await NavigationService.NavigateToAsync<EnglishWordViewModel>();
        }

        public DelegateCommand LoadWordsCommand => new DelegateCommand(async () => await LoadWordsCommandExecute());

        private async Task LoadWordsCommandExecute()
        {
            await DataStoreService.ReadWords();
        }
    }
}
