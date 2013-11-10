namespace Wpf.MessageOverlay.ViewModels
{
    public sealed class FooterViewModel : ViewModel, IFooterViewModel
    {
        public FooterViewModel(IBusyMonitor busyMonitor)
            : base(busyMonitor)
        {
        }
    }
}