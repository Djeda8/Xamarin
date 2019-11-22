using Autofac;
using EnglishApp.dou.com.Services.DataStore;
using EnglishApp.dou.com.Services.Navigation;
using EnglishApp.dou.com.ViewModels.EnglishWord;
using EnglishApp.dou.com.ViewModels.Main;
using System;

namespace EnglishApp.dou.com.ViewModels.Base
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
            builder.RegisterType<EnglishWordViewModel>();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<DataStoreService>().As<IDataStoreService>();


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
