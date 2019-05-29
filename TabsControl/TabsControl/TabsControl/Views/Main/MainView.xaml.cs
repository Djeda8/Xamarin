using System;
using TabsControl.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabsControl.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
            Title = AppSettings.AppTitle;
            NavigationPage.SetHasBackButton(this, false);
            this.CurrentPageChanged += tabChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var masterPage = this;
            masterPage.CurrentPage = masterPage.Children[1]; //Go to Tab page 2
            masterPage.CurrentPage.Focus();

            var bindingContext = BindingContext as ViewModelBase;
            bindingContext?.ChangeActiveTab(1);
        }

        protected override void OnDisappearing()
        {
            var bindingContext = BindingContext as ViewModelBase;
            bindingContext?.OnBackButtonPressed();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected void tabChanged(object sender, EventArgs args)
        {
            var i = this.Children.IndexOf(this.CurrentPage);
            var bindingContext = BindingContext as ViewModelBase;
            bindingContext?.ChangeActiveTab(i);
        }
    }
}