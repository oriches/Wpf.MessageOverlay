namespace Wpf.MessageOverlay.ViewModels
{
    public sealed class BusyMonitor : Monitor, IBusyMonitor
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                SetPropertyAndNotify(ref _isBusy, value, () => IsBusy);
            }
        }
    }
}