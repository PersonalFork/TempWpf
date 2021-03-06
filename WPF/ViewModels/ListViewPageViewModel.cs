using Prism.Commands;
using Prism.Regions;
using WPF.Common;
using WPF.ViewModels.Base;

namespace WPF.ViewModels
{
    public class ListViewPageViewModel : ViewModelBase
    {
        public DelegateCommand BackCommand { get; set; }
        public ListViewPageViewModel(IRegionManager regionManager) : base(regionManager)
        {
            BackCommand = new DelegateCommand(DoGoBack);
        }

        private void DoGoBack()
        {
            RegionManager.RequestNavigate(Regions.ContentRegion, Pages.HomePage);
        }

        public override void Activate()
        {
        }

        public override void Deactivate()
        {
        }
    }
}
