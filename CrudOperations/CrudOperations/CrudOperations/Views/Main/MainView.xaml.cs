using CrudOperations.Services.Sqlite;
using CrudOperations.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudOperations.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            Title = "CRUD";
            BindingContext = new MainViewModel(new SqliteService());
        }
    }
}