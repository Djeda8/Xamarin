## Create a navigation service menu.

1. Start from a project with __Basic MVVM__.

2. Put in the view *Main* the __buttons__ for the options.

3. In the *MainViewModel* create the __delegates__ and __commands executes methods__ for each option.

4. __Call__ the views in the *commands executes methods* of the MainViewModel.

5. Inside the *folder views* create a __view__ for each option of the menu.

6. Inside the folder *viewModels* create a __viewModel__ for each view.

7. In the *Navigation service* add the __mapping__ of the ViewModels and the views.

8. In the constructor of the *ViewModelLocator* register the __ViewModels__.

9. In the *ViewModelBase* class you must declare the __NavigationService__.

10. In the constructor of the *ViewModelBase* you must create a instance of the __NavigationService__.

> Note: The navigation service must be resitered in the MainViewLocator. 
> In the ViewModelBase you must declare the service navigation and you must create an instance in the constructor.

