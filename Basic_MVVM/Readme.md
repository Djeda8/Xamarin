## Initialize basic MVVM

1. Start from an app *Xamarin.Forms for the Android platform*.

2. Create a Services folder with Navigation subfolder.

3. In the *Services/Navigation* subfolder add the __INavigationServices__ interface.

4. In the *Services/Navigation* subfolder implement the __NavigationService__.

5. In the App.xaml.cs code behind call __InitNavigation()__ method in the constructor.

6. In the App.xaml.cs code behind implement the __InitNavigation()__ method.

7. Create a Views folder with two subfolders Main and Base.

8. In the *View/Base* subfolder add the __CustomNavigationPage.xaml__ view with their code behind.

9. In the *View/Main* subfolder add the __MainView.xaml__ view with their code behind.

10. Create a ViewModels folder with two subfolders Main and Base.

11. In the *ViewModels/Base* subfolder add the __DelegateCommand.cs, ViewModelBase.cs and ViewModelLocator.cs__ class.

12. In the *ViewModels/Main* subfolder add the __MainViewModel.cs__ class.

> Note: The Basic_MVVM project needs the Autofac package.
