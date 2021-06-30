using Ikc5.TypeLibrary.Logging;
using System.Windows;
using Unity;
using Unity.Lifetime;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IService _chartService = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            container.RegisterType<ILogger, EmptyLogger>();
            container.RegisterType<IChartRepository, ChartRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IService, ChartService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            container.RegisterType<IColumnChartViewModel, ColumnChartViewModel>();

            _chartService = container.Resolve<IService>();
            var mainWindow = container.Resolve<MainWindow>();
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();

            _chartService.OnStart();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _chartService.OnStop();
            base.OnExit(e);
        }
    }
}
