using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabsControl.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabView2 : ContentPage
    {
        public TabView2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}