using System.Windows;
using Prism.Ioc;
using WPF.Common;
using WPF.Views;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage>(Pages.HomePage);
            containerRegistry.RegisterForNavigation<DataGridPage>(Pages.DataGridPage);
            containerRegistry.RegisterForNavigation<ListViewPage>(Pages.ListViewPage);
        }
    }
}
