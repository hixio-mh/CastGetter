using System;
using SimpleInjector;
using CastGetter.VM;
using CastGetter.Interface;
using CastGetterLib;

namespace CastGetter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = Bootstrap();

            // Any additional other configuration, e.g. of your desired MVVM toolkit.

            RunApplication(container);
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            //container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Singleton);
            //container.Register<IUserContext, WpfUserContext>();

            // Register your windows and view models:
            container.Register<MainWindow>();
            container.Register<MainWindowViewModel>();
            container.Register<IPodcastSource, ITunesPodcastSource>();

            container.Verify();

            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
            }
        }
    }
}
