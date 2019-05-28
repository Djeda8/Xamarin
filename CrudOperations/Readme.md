## How to do an app¡¡

The easiest way to make an app is to think what you need at all times.

This tells us the order in which we must create the classes.

It is important to be ordered and place everything in its project folder.

>> Note: The proyect needs the Sqlite-net and autofac packages.

1. Begin adding the AppSettings.cs

2. We first must create the __MainView.xaml__ with the code behind.

3. Create the model __User.cs__.

4. After we add the __MainViewModel.cs__ and binding the context to the MainView in the code behind.

5. You must add the __ViewMmodelBase.cs__ and the __DelegateCommand.cs.

6. In the *App.xaml.cs* change the __MainView__.

7. Create the Services and their interfaces PathServices, SqliteService. Don't forget the service in the Xamarin.Droid project.

8. Add the helper. 



