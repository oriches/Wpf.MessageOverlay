namespace Wpf.MessageOverlay.ViewModels
{
    public sealed class MainViewModel : ViewModel, IMainViewModel
    {
        public MainViewModel(IBusyMonitor busyMonitor, IMessageMonitor messageMonitor,
            IHeaderViewModel headerViewModel,
            IContentViewModel contentViewModel,
            IFooterViewModel footerViewModel)
            : base(busyMonitor, messageMonitor)
        {
            HeaderPane = headerViewModel;
            ContentPane = contentViewModel;
            FooterPane = footerViewModel;
        }

        public IViewModel HeaderPane { get; private set; }

        public IViewModel ContentPane { get; private set; }

        public IViewModel FooterPane { get; private set; }
    }
}