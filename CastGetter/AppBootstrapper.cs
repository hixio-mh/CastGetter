using System.Windows;
using Caliburn.Micro;
using CastGetter.ViewModels;
using SimpleInjector;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using CastGetter.Interface;
using CastGetterLib;

namespace CastGetter
{
    public class AppBootstrapper : BootstrapperBase
    {
        public static readonly Container ContainerInstance = new Container();
        public AppBootstrapper()
        {
            //LogManager.GetLog = type => new DebugLogger(type);
            Initialize();
        }
        protected override void Configure()
        {
            ContainerInstance.Register<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<IEventAggregator, EventAggregator>();

            ContainerInstance.Register<MainWindowViewModel, MainWindowViewModel>();
            ContainerInstance.Register<IPodcastSource, TunesPodcastSource>();

            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            IServiceProvider provider = ContainerInstance;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        protected override object GetInstance(System.Type service, string key)
        {
            return ContainerInstance.GetInstance(service);
        }
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                Assembly.GetExecutingAssembly()
            };
        }
        protected override void BuildUp(object instance)
        {
            var registration = ContainerInstance.GetRegistration(instance.GetType(), true);
            registration.Registration.InitializeInstance(instance);
        }
    }
}
