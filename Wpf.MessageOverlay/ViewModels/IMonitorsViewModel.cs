namespace Wpf.MessageOverlay.ViewModels
{
    public interface IMonitorsViewModel
    {
        IBusyMonitor BusyMonitor { get; }

        IMessageMonitor MessageMonitor { get; }
    }
}