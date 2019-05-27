using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicDebug.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        Button debugButton;
        public MainView()
        {
            InitializeComponent();
            debugButton = new Button { Text = "Debug Button" };
           

            debugButton.Clicked += (sender, e) =>
            {
                Debug.WriteLine("You has pressed the debug button.");
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label
                    {
                        Text = "Basic Debug",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label { Text = "Press the button and look the output window." },
                    debugButton,
                }
            };
        }
    }
}