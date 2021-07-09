using Prism.Commands;
using Prism.Regions;
using WPF.Common;
using WPF.ViewModels.Base;

namespace WPF.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public DelegateCommand<object> NavigateCommand { get; set; }
        public HomePageViewModel(IRegionManager regionManager) : base(regionManager)
        {
            NavigateCommand = new DelegateCommand<object>(DoNavigate);
        }

        private void DoNavigate(object pageName)
        {
            if (pageName != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    RegionManager.RequestNavigate(Regions.ContentRegion, pageName.ToString());
                });
            }
        }

        public override void Activate()
        {
        }

        public override void Deactivate()
        {
        }
    }
}
