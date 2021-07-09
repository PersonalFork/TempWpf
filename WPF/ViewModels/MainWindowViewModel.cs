using System.Threading.Tasks;
using Prism.Regions;
using WPF.Common;
using WPF.ViewModels.Base;

namespace WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Task.Run(() =>
            {
                Activate();
            });
        }

        private bool _isActivated = false;
        public override void Activate()
        {
            if (_isActivated == false)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    RegionManager.RequestNavigate(Regions.ContentRegion, Pages.HomePage);
                    _isActivated = true;
                });
            }
        }

        public override void Deactivate()
        {
        }
    }
}
