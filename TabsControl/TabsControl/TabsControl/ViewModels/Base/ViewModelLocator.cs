﻿using Autofac;
using System;
using TabsControl.Services.Navigation;
using TabsControl.ViewModels.Main;

namespace TabsControl.ViewModels.Base
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
