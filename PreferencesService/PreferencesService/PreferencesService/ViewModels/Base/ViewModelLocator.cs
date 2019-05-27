using Autofac;
using PreferencesService.Services.Dialog;
using PreferencesService.Services.Navigation;
using PreferencesService.Services.Preferences;
using PreferencesService.Services.Sqlite;
using PreferencesService.ViewModels.Main;
using PreferencesService.ViewModels.Settings;
using System;

namespace PreferencesService.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static IContainer _container;
        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<SettingsViewModel>();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<SqliteService>().As<ISqliteService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<Services.Preferences.PreferencesService>().As<IPreferencesService>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
