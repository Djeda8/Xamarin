## Create a navigation service menu.

1. Start from a project with basic MVVM.

2. Put in the view Main the buttons for the options.

3. In the MainViewModel create the delegates and commands executes methods for each option.

4. Call the views in the commands executes methods of the MainViewModel.

5. Inside the folder views create a view for each option of the menu.

6. Inside the folder viewModels create a viewModel for each view.

7. In the Navigation service add the mapping of the ViewModels and the views.

8. In the constructor of the ViewModelLocator register the ViewModels.

> Note: The navigation service must be resitered in the MainViewLocator. 
> In the ViewModelBase you must declare the service navigation and you must create an instance in the constructor.

