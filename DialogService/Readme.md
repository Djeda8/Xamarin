## Create and use a Dialog Service

1. Start from a project with __basic MVVM__.

2. Create a __Services__ folder with __Dailog__ subfolder.

3. In the *Services/Dailog* subfolder add the __IDailogServices__ interface.

4. In the *Services/Dailog* subfolder implement the __DailogService__.

5. In the *ViewModelLocator class* you must resgister the __DialogService__.

6. In the *ViewModelBase class* you must declare the __DialogService__.

7. In the *constructor of the ViewModelBase* you must create a instance of the __DialogService__.

> Note: The project needs the Autofac package.