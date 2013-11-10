namespace Wpf.MessageOverlay.ViewModels
{
    using Commands;

    public interface IContentMessageViewModel : IMessageViewModel
    {
        string Message { get; }

        IObservableCommand BusyAndCloseCommand { get; }
    }
}