using Prism.Mvvm;
using Prism.Regions;

namespace WPF.ViewModels.Base
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        public IRegionManager RegionManager { get; }
        public ViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Activate();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Deactivate();
        }

        public abstract void Activate();
        public abstract void Deactivate();
    }
}
