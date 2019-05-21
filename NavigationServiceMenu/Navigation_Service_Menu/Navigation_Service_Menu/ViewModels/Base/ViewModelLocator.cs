using Autofac;
using Navigation_Service_Menu.Services.Navigation;
using Navigation_Service_Menu.ViewModels.Main;
using Navigation_Service_Menu.ViewModels.Screen1;
using Navigation_Service_Menu.ViewModels.Screen2;
using Navigation_Service_Menu.ViewModels.Screen3;
using Navigation_Service_Menu.ViewModels.Screen4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation_Service_Menu.ViewModels.Base
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
            builder.RegisterType<Screen1ViewModel>();
            builder.RegisterType<Screen2ViewModel>();
            builder.RegisterType<Screen3ViewModel>();
            builder.RegisterType<Screen4ViewModel>();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>();


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
