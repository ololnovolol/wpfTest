using System;
using System.IO;
using System.Windows;
using CementAndConcrete.BLL.DiContainers;
using CementAndConcrete.WPF.Views;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Modules;

namespace CementAndConcrete.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public partial class App
    {
        /// <summary>
        ///     Holds the container for dependency injection.
        /// </summary>
        private IKernel? сontainer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public App()
        {
            сontainer = new StandardKernel();
        }

        /// <summary>
        ///     Installs the application.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="eventArgs">Contains StartEventArgs object</param>
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            base.OnStartup(eventArgs);
            Configure();
            ComposeObjects();

            Current.MainWindow?.Show();
        }

        /// <summary>
        ///     Fills a DI container with objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        private void Configure()
        {
            NinjectModule unitOfWorkModule = new UnitOfWorkService(GetConnectionString());
            NinjectModule tableModule = new TableServiceDi();
            NinjectModule consumerModule = new CustomerServiceDi();
            NinjectModule orderModule = new OrderServiceDi();
            NinjectModule materialModule = new MaterialServiceDi();
            NinjectModule builderModule = new BuilderServiceDi();

            сontainer = new StandardKernel(
                unitOfWorkModule,
                tableModule,
                consumerModule,
                orderModule,
                materialModule,
                builderModule);
        }

        /// <summary>
        ///     Gets connection string into config file.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>The connectString data.</returns>
        private static string GetConnectionString()
        {
            string curDir = Directory.GetCurrentDirectory();
            DirectoryInfo? baseDir = Directory.GetParent(curDir)?.Parent?.Parent;

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile(@$"{baseDir}\config.json")
                .Build();

            return config["ConnectionStrings:DbConnection"] ??
                   throw new InvalidOperationException("connectionString problem in config file")
                   {
                       HelpLink = null, HResult = 0, Source = null
                   };
        }

        /// <summary>
        ///     Main window anchor.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        private void ComposeObjects()
        {
            IKernel? kernel = сontainer;

            if (kernel != null)
            {
                Current.MainWindow = kernel.Get<MainWindow>();
            }

            AddWindowTitle();
        }

        /// <summary>
        ///     View binding.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        private static void AddWindowTitle()
        {
            if (Current.MainWindow != null)
            {
                Current.MainWindow.Title = "Cement & Concrete";
            }
        }
    }
}