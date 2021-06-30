using Unity;

namespace WpfApplication.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }

        #region IMainWindowViewModel

        [Dependency]
        public IColumnChartViewModel ColumnChartViewModel { get; set; }

        #endregion
    }
}