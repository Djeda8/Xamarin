using SearchBarMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarRealtime : ContentPage
    {
        public SearchBarRealtime()
        {
            InitializeComponent();
        }
        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var bindingContext = BindingContext as SearchBarViewModel;
            bindingContext?.PerformSearchRealtime(e.NewTextValue);
        }
    }
}