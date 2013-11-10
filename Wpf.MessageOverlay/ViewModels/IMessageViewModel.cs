namespace Wpf.MessageOverlay.ViewModels
{
    using Commands;

    public interface IMessageViewModel : IViewModel
    {
        IObservableCommand CloseCommand { get; }
    }
}