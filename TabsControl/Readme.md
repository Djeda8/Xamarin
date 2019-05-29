## Tabs control

You can control which tab you want to see when you open a tabbed page.
You can obtein the id of the tab when you change the current tab page.
Tou can use other context for calling methods in other class.

1. We begin from a *project with navigation service*.

2. Add the __MainView__ as a TabbedPage and the __TabView 1 and 2__.

3. We only must to indicate that we don't want to see the __NavigationBar__ in the *TabViews.cs 1 and 2*.

3. In the *MainView*, we can indicate that we don't want to see the __BackButton__.

4. We add an event __CurrentPageChanged__ in the *constructor*.

5. We indicate the tab to open in the *OnAppearing method*.

6. We use the __BindingContext__ to execute the ViewModelBase __ChangeActiveTab__ method.

7. The app detect the *active tab* each time we change the tab with the event *CurrentPageChanged* and execute the __tabChanged__ method.

8. In the *ViewModelBase* with the __ChangeActiveTab__ method, we show the active tab *in the output window*.